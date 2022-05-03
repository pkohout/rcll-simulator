﻿using System;
using System.Collections.Generic;
using System.Threading;
using LlsfMsgs;
using Simulator.Utility;
using Terminal.Gui;
using Simulator.MPS;


namespace Simulator.RobotEssentials
{
    public class Robot
    {
        public string RobotName { get; }
        public string TeamName { get; }
        public uint JerseyNumber { get; }
        public Team TeamColor { get; }
        public CPosition Position { get; set; }
        private readonly MyLogger MyLogger;
        private readonly RobotTeamserver? Teamserver;
        private readonly RobotRefbox? Refbox;
        private bool Running;
        private Products? HeldProduct;
        private GameState.Types.State GameState;
        private GameState.Types.Phase GamePhase;
        private RobotState RobotState;
        private Zones? CurrentZone;
        private readonly Queue<GripsMidlevelTasks> Tasks;
        public GripsMidlevelTasks? CurrentTask { get; set; }
        private DateTime MoveStart = DateTime.MinValue;
        public List<RobotMachineReportEntry> Machines { get; set; }
        public Thread? WorkingRobotThread { get; set; }
        private RobotManager MyManager;
        public Window? RobotView { get; set; }
        private readonly Configurations Config;
        public string TaskDescription { get; private set; }
        public ManualResetEvent WaitForPrepare { get; private set; }
        private MpsManager? MpsManager;
        public Robot(string name, RobotManager manager, Team color, int jersey, bool debug = false)
        {
            Config = Configurations.GetInstance();
            RobotName = name;
            TeamName = Config.Teams[0].Name;
            TeamColor = color;
            Position = new CPosition(5f, 1f, 0);
            MyManager = manager;
            JerseyNumber = (uint)jersey;
            /*
            HeldProduct = new Products();
            HeldProduct.AddPart(new BaseElement(BaseColor.BaseBlack));
            HeldProduct.AddPart(new RingElement(RingColor.RingBlue));
            HeldProduct.AddPart(new CapElement(CapColor.CapBlack));
            */
            MyLogger = new MyLogger(this.JerseyNumber + "_" + this.RobotName, debug);
            Running = true;
            RobotState = RobotState.Active;
            WaitForPrepare = new ManualResetEvent(false);
            if (!Config.MockUp)
            {
                Teamserver = new RobotTeamserver(this, MyLogger);
            }
            CurrentZone = null;
            Tasks = new Queue<GripsMidlevelTasks>();
            Machines = new List<RobotMachineReportEntry>();
            TaskDescription = "Idle";
            MpsManager = null;

        }


        public string GetHeldProductString()
        {
            return HeldProduct == null ? "no Product" : HeldProduct.ProductDescription();
        }
        public bool IsHoldingSomething()
        {
            return HeldProduct != null ? true : false;
        }
        public Zones? GetZone()
        {
            return CurrentZone;
        }

        public void SetZone(Zones zone)
        {
            CurrentZone = zone;
            Position = new CPosition(zone.X, zone.Y, 0);
        }

        public void SetGameState(GameState gs)
        {
            if (gs.HasPhase)
            {
                GamePhase = gs.Phase;
            }

            if (gs.HasState)
            {
                GameState = gs.State;
            }

            if (gs.HasTeamCyan)
            {
                //gs.TeamCyan;
            }
        }

        public void SetGripsTasks(GripsMidlevelTasks task)
        {
            switch (Config.IgnoreTeamColor)
            {
                case true when CurrentTask != null && task.CancelTask && task.TaskId == CurrentTask.TaskId:
                    MyLogger.Log("Current task should be canceled!");
                    //TODO added canceling of tasks, need to evaluate if behaviour is now correct!
                    CurrentTask.Canceled = true;
                    CurrentTask.Successful = true;
                    Teamserver.AddMessage(Teamserver.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks));
                    return;
                case true:
                {
                    var check = false;
                    foreach (var t in Tasks)
                    {
                        if (t.TaskId == task.TaskId)
                        {
                            MyLogger.Log("Current Task is already in the list!");
                            check = true;
                            return;
                        }
                    }

                    if (!check)
                    {
                        MyLogger.Log("Added a new Task!");
                        MyLogger.Log(task.ToString());
                        Tasks.Enqueue(task);
                    }
                    else
                    {
                        MyLogger.Log("The task with id " + task.TaskId + " is already in my task list!");
                    }

                    break;
                }
                case false when task.RobotId == this.JerseyNumber && task.TeamColor == this.TeamColor:
                {
                    if (CurrentTask != null && task.CancelTask && task.TaskId == CurrentTask.TaskId)
                    {
                        MyLogger.Log("Current task should be canceled!");
                    }
                    MyLogger.Log("Added a new Task!");
                    MyLogger.Log(task.ToString());
                    Tasks.Enqueue(task);
                    break;
                }
                default:
                    MyLogger.Log("The received task is not for me, will ignore!");
                    break;
            }
        }

        public void Run()
        {
            MyLogger.Log("Robot " + RobotName + " is starting!");
            Refbox?.Start();
            Teamserver?.Start();

            MyLogger.Log("Starting " + RobotName + "'s working thread! Mockup = " +
                         Configurations.GetInstance().MockUp.ToString());
            if (Config.MockUp)
            {
                WorkMockup();
            }
            else
            {
                Work();
            }
        }

        public void Test()
        {
            var msg = Teamserver?.GetTestMessage();
            if (msg != null)
            {
                MyLogger.Log(msg);
            }
        }
        #region BasicBehaviour

        private bool Move(Zone TargetZone)
        {
            var attempt = 0;
            var path = ZonesManager.GetInstance().Astar(CurrentZone, ZonesManager.GetInstance().GetZone(TargetZone));
            MyLogger.Log(path.Count != 0 ? "Got a Path!" : "No Path could be computed!!");
            foreach (var z in path)
            {
                TaskDescription = "Moving to " + z.ZoneId;
                MyLogger.Log("Doing a step towards + " + z.ZoneId);
                MyLogger.Log("Getting the Mutex from zone " + z.ZoneId.ToString());
                z.ZoneMutex.WaitOne();
                MyLogger.Log("Got the Mutex from zone " + z.ZoneId.ToString());
                for (attempt = 0; attempt < 3; attempt++)
                {
                    MyLogger.Log("Attempting a Move [" + attempt + "/3]");
                    if (CurrentTask is { Canceled: true })
                    {
                        MyLogger.Log("The task I'm working on has been canceled!");
                        return false;
                    }
                    if (z.GetsMovedTo || z.Robot != null)
                    {
                        MyLogger.Log("Space is already Occupied!");
                        Thread.Sleep(Config.RobotMoveZoneDuration);
                        continue;
                    }
                    z.GetsMovedTo = true;
                    Thread.Sleep(Config.RobotMoveZoneDuration);
                    CurrentZone.RemoveRobot();
                    if (ZonesManager.GetInstance().PlaceRobot((Zone)z.ZoneId, 0, this))
                    {
                        SetZone(z);
                        MyLogger.Log("Step is finished after [" + attempt + "/3] !");
                        attempt = 4;
                        z.GetsMovedTo = false;
                        break;
                    }

                    z.GetsMovedTo = false;
                }
                z.ZoneMutex.ReleaseMutex();
            }

            if (attempt != 4)
            {
                MyLogger.Log("Failed due to exceding amount of try's");
                CurrentTask.Successful = false;
                return false;
            }
            else
            {
                MyLogger.Log("Finishing the move command");
                return true;
            }

        }
        private bool GripProduct(Mps mps, string machinePoint = "output", uint shelfNumber = 0)
        {
            MyLogger.Log("At station starting the GRIP Action!");
            TaskDescription = "Grasping Product";
            var attempts = 0;
            while (HeldProduct == null && attempts < 60)
            {
                MyLogger.Log("[Attempt nr " + attempts + "] Trying to get a product from the machine!");
                Thread.Sleep(1000);
                HeldProduct = mps.Type switch
                {
                    Mps.MpsType.BaseStation => ((MPS_BS)mps).RemoveProduct(machinePoint),
                    Mps.MpsType.CapStation => ((MPS_CS)mps).RemoveProduct(machinePoint),
                    Mps.MpsType.RingStation => ((MPS_RS)mps).RemoveProduct(machinePoint),
                    _ => null
                };
                //Teamserver.AddMessage(message);
                attempts++;
            }
            TaskDescription = "Idle";
            if (HeldProduct != null)
            {
                MyLogger.Log("Got a new Product!");
                MyLogger.Log(HeldProduct.ProductDescription());
                return true;
            }
            else
            {
                MyLogger.Log("Was not able to grasp the product!");
                return false;
            }
        }

        #endregion
        #region Grips Tasks
        private void MoveToWaypoint()
        {
            MyLogger.Log("Move To Waypoint task!");
            TaskDescription = "Moving to Waypoint";
            if (CurrentTask == null)
            {
                MyLogger.Log("MoveToWayPoint -> current task is NULL!");
                return;
            }
            var Waypoint = CurrentTask.MoveToWaypoint.Waypoint;
            Zone targetZone = ZonesManager.GetInstance().GetWaypoint(Waypoint);
            if (targetZone == 0)
            {
                MyLogger.Log("Couldn't find the machine position!");
                TaskDescription = "Idle";
                CurrentTask.Successful = false;
                var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                if (message != null)
                {
                    Teamserver?.AddMessage(message);
                }
                return;
            }
            //todo add check why task was unsuccessful and if pathing failed replan the path
            if (Move(targetZone))
            {
                MyLogger.Log("Finished the move to waypoint successfull!");
                CurrentTask.Successful = true;
            }
            else
            {
                MyLogger.Log("Finished the move to waypoint unsuccessfull!");
                if (CurrentTask.Canceled)
                {
                    TaskDescription = "Idle";
                    return;
                }
                CurrentTask.Successful = false;
            }

            if (!Config.MockUp)
            {
                var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                if (message != null)
                {
                    Teamserver?.AddMessage(message);
                }
            }


            TaskDescription = "Idle";
        }


        public void GetFromStation()
        {
            MyLogger.Log("Get From Station task!");
            TaskDescription = "GetFromStationTask";
            if (CurrentTask == null)
            {
                MyLogger.Log("GetFromStation -> the current task is NULL!");
                return;
            }
            var machine = CurrentTask.GetFromStation.MachineId;
            MpsManager ??= MpsManager.GetInstance();
            var mps = MpsManager.GetMachineViaId(CurrentTask.GetFromStation.MachineId);
            var target = CurrentTask.GetFromStation.MachinePoint;
            Zone targetZone = ZonesManager.GetInstance().GetWaypoint(machine);
            if(targetZone == 0)
            {
                MyLogger.Log("Couldnt find the requested target machine!");
                if(!Config.MockUp)
                {
                    CurrentTask.Successful = false;
                    //TODO maybe add feedback for wrongly issued targets
                }
                return;
            }
            if (targetZone == CurrentZone?.ZoneId)
            {
                MyLogger.Log("I am in position to do my task!");
            }
            else
            {
                if (mps.Type == Mps.MpsType.CapStation && !target.Equals("output"))
                {
                    MyLogger.Log("Prepare in case of a CapStation!");
                    if(Config.SendPrepare)
                    {
                        PrepareMachine();
                    }

                }
                CurrentTask.Successful = Move(targetZone);
                if (!Configurations.GetInstance().MockUp && !CurrentTask.Successful)
                {
                    MyLogger.Log("Movement was not successful we interrupt the task!");
                    var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                    if (message != null)
                    {
                        Teamserver?.AddMessage(message);
                        return;
                    }
                }
            }
            if (!Configurations.GetInstance().MockUp)
            {

                MyLogger.Log("At station sending a prepare machine task!");
                switch (mps.Type)
                {
                    case Mps.MpsType.BaseStation:
                        {
                            if (Config.SendPrepare)
                            {
                                PrepareMachine();
                            }
                            break;
                        }
                }
            }
            if(mps == null)
            {
                MyLogger.Log("The Machine was not found? Griping not possible?");
                CurrentTask = null;
                return;
            }
            CurrentTask.Successful = GripProduct(mps, target);
            if (!Configurations.GetInstance().MockUp)
            {
                var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                if (message != null)
                {
                    Teamserver?.AddMessage(message);
                }
            }
            CurrentTask = null;
            TaskDescription = "Idle";
        }
        private void DeliverToStation()
        {
            MyLogger.Log("DeliverToStation!");
            TaskDescription = "DeliverToStationTask";
            if (CurrentTask == null)
            {
                return;
            }
            var machine = CurrentTask.DeliverToStation.MachineId;
            var target = CurrentTask.DeliverToStation.MachinePoint;
            Zone targetZone = ZonesManager.GetInstance().GetWaypoint(machine);
            MyLogger.Log("Target zone = " + targetZone);
            if (targetZone == CurrentZone.ZoneId)
            {
                MyLogger.Log("I am in position to do my task!");
            }
            else
            {
                CurrentTask.Successful = Move(targetZone);
                if (!Config.MockUp && !CurrentTask.Successful)
                {
                    MyLogger.Log("Movement was not successful we interrupt the task!");
                    var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                    if (message != null)
                    {
                        Teamserver?.AddMessage(message);
                        return;
                    }
                }
            }
            MyLogger.Log("Placing the product on the machine!");
            MpsManager ??= MpsManager.GetInstance();
            var mps = MpsManager.GetMachineViaId(machine);
            switch (mps.Type)
            {
                case MPS.Mps.MpsType.RingStation:
                    {
                        ((MPS_RS)mps).PlaceProduct(target, HeldProduct);
                        if(Config.SendPrepare)
                        {
                            PrepareMachine();
                        }
                        break;
                    }
                case MPS.Mps.MpsType.DeliveryStation:
                    {
                        mps.PlaceProduct(target, HeldProduct);
                        if(Config.SendPrepare)
                        {
                            PrepareMachine();
                        }
                        break;
                    }
                default:
                    mps.PlaceProduct(target, HeldProduct);
                    break;
            }

            HeldProduct = null;

            if (!Config.MockUp)
            {
                CurrentTask.Successful = true;
                var message = Teamserver.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                if (message != null)
                {
                    Teamserver.AddMessage(message);
                }
            }
            TaskDescription = "Idle";
        }
        private void BufferCapStation()
        {
            MyLogger.Log("BufferCapStation!");
            var machine = CurrentTask?.BufferCapStation.MachineId;
            var target = CurrentTask?.BufferCapStation.ShelfNumber;
            MpsManager ??= MpsManager.GetInstance();
            var mps = MpsManager.GetMachineViaId(machine);
            if (GripProduct(mps, "shelf" + target.ToString()))
            {
                MyLogger.Log("Was able to get a Product from the shelf" + target.ToString());
            }

            MyLogger.Log("Trying to place the currently held Product on the input side of the CS");
            mps.PlaceProduct("input", HeldProduct);
            MyLogger.Log("Next we need to send a prepare machine to the teamserver!");
            if(Config.SendPrepare)
            {
                PrepareMachine();
            }
            
            MpsManager ??= MpsManager.GetInstance();

            if (CurrentTask == null)
            {
                return;
            }
            MyLogger.Log("Buffered the machine!");
            CurrentTask.Successful = true;
            var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
            if (message != null)
            {
                Teamserver?.AddMessage(message);
            }
            TaskDescription = "Idle";
        }
        private void ExploreMachine()
        {
            MyLogger.Log("ExploreMachine!");
            Thread.Sleep(1000);
            if (CurrentTask == null)
            {
                return;
            }
            CurrentTask.Successful = true;
            var message = Teamserver.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
            if (message != null)
            {
                Teamserver.AddMessage(message);
            }

        }
        private void Explore()
        {
            MyLogger.Log("Current Zone = " + CurrentZone.ToString());
        }
        private void PrepareMachine()
        {
            var message = Teamserver?.CreateMessage(PBMessageFactory.MessageTypes.GripsPrepareMachine);
            MyLogger.Log("Tried to create a GripPrepareMachineTask!");
            if (message != null)
            {
                MyLogger.Log("Sending a GripsPrepareMachineTask!");
                Teamserver?.AddMessage(message);
                return;
            }
            MyLogger.Log("No Prepare machine task can be sent!");
            return;
        }
        #endregion
        public void Work()
        {
            while (Running)
            {
                switch (RobotState)
                {
                    case RobotState.Active:

                        if (CurrentTask != null)
                        {
                            //TODO refactor new task handling
                            //{ "teamColor": "MAGENTA", "taskId": 57, "robotId": 1, "getFromStation": { "machineId": "C-CS2", "machinePoint": "shelf0" } }
                            //tasks
                            MyLogger.Log("Current tasks = " + Tasks.Count.ToString());
                            //{ "teamColor": "MAGENTA", "taskId": 0, "robotId": 2 }
                            MyLogger.Log("#######################################################################");
                            MyLogger.Log("The current task = " + CurrentTask.ToString());
                            MyLogger.Log("#######################################################################");
                            if (CurrentTask.ReportAllSeenMachines)
                            {
                                MyLogger.Log("Got a Report all seen Machines flag!");
                                //todo add a answer to report all seen machines
                                var message = Teamserver.CreateMessage(PBMessageFactory.MessageTypes.ReportAllMachines);
                                if (message != null)
                                {
                                    Teamserver.AddMessage(message);
                                }

                            }

                            if (CurrentTask.PauseTask)
                            {
                                MyLogger.Log("Got a pause robot task [" + CurrentTask.PauseTask.ToString() +
                                             "] --- task is done!");
                            }
                            if (CurrentTask.HasCancelTask)
                            {
                                MyLogger.Log("Got a Cancel Task!");
                            }

                            if (CurrentTask.MoveToWaypoint != null)
                            {
                                MoveToWaypoint();
                                CurrentTask = null;
                            }
                            else if (CurrentTask.GetFromStation != null)
                            {

                                GetFromStation();
                                CurrentTask = null;
                            }
                            else if (CurrentTask.DeliverToStation != null)
                            {
                                DeliverToStation();
                                CurrentTask = null;
                            }
                            else if (CurrentTask.BufferCapStation != null)
                            {
                                BufferCapStation();
                                CurrentTask = null;
                            }
                            else if (CurrentTask.ExploreMachine != null)
                            {
                                ExploreMachine();
                                CurrentTask = null;
                            }
                            else
                            {
                                if (Configurations.GetInstance().IgnoreTeamColor)
                                {
                                    /*
                                    var message = Teamserver.CreateMessage(PBMessageFactory.MessageTypes.GripsMidlevelTasks);
                                    if(message != null)
                                    {
                                        Teamserver.AddMessage(message);
                                    }
                                    */
                                    CurrentTask = null;
                                }
                                else
                                {
                                    if (CurrentTask.TeamColor != TeamColor)
                                    {
                                        MyLogger.Log("Got a task thats not for me. I ignore it!");
                                        CurrentTask = null;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Tasks.Count != 0)
                            {
                                MyLogger.Log("No Current task, fetching a new one from my task list!");
                                CurrentTask = Tasks.Dequeue();
                                MyLogger.Log("The new task = " + CurrentTask.ToString());
                            }
                            else
                            {
                                MyLogger.Log("No Tasks currently!");
                                //TestMove();
                            }
                        }


                        break;
                    case RobotState.Disqualified:
                        break;
                    case RobotState.Maintenance:
                        break;
                    default:
                        break;
                }

                string taskstring = "No task!";
                if (CurrentTask is { HasTaskId: true })
                {
                    taskstring = CurrentTask.TaskId.ToString();
                }

                MyLogger.Log("is [" + RobotState.ToString() + "] and doing his " + taskstring + "! Gamephase is [" +
                             GamePhase.ToString() + "] and GameState = [" + GameState.ToString() + "]");
                Thread.Sleep(1000);
            }
        }

        public void WorkMockup()
        {
            MyLogger.Log("Entered WorkMockup! Running = " + Running.ToString());
            while (Running)
            {
                //MyLogger.Log("is [" + RobotState.ToString() + "] and doing his job! Gamephase is [" +
                //             GamePhase.ToString() + "] and GameState = [" + GameState.ToString() + "]");
                if (CurrentTask != null)
                {
                    if (CurrentTask.MoveToWaypoint != null)
                    {
                        MoveToWaypoint();
                        CurrentTask = null;
                    }
                    else if (CurrentTask.GetFromStation != null)
                    {
                        GetFromStation();
                        CurrentTask = null;
                    }
                    else if (CurrentTask.DeliverToStation != null)
                    {
                        DeliverToStation();
                        CurrentTask = null;
                    }
                    else if (CurrentTask.BufferCapStation != null)
                    {
                        BufferCapStation();
                        CurrentTask = null;
                    }
                    else if (CurrentTask.ExploreMachine != null)
                    {
                        ExploreMachine();
                        CurrentTask = null;
                    }
                }
                else
                {
                    if (Tasks.Count != 0)
                    {
                        MyLogger.Log("No Current task, fetching a new one from my task list!");
                        CurrentTask = Tasks.Dequeue();
                        MyLogger.Log("The new task = " + CurrentTask.ToString());
                    }
                    else
                    {
                        //MyLogger.Log("No Tasks currently!");
                        //TestMove();
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void TestMove()
        {
            GripsMidlevelTasks task = new GripsMidlevelTasks()
            {
                RobotId = 0,
                TaskId = 1,
                TeamColor = TeamColor,
                MoveToWaypoint = new MoveToWaypoint
                {
                    Waypoint = "Test Zone"
                }
            };
            CurrentTask = task;
        }

        public void UpdateProduct(Products prod)
        {
            HeldProduct = prod;
        }

        public void RobotStop()
        {
            Running = false;
        }

        public string GetTaskDescription()
        {
            return TaskDescription;
        }
        public string GetDebugLog(int lines)
        {
            return MyLogger.GetLines(lines);
        }
        public string GetConnectionState()
        {
            if (Configurations.GetInstance().MockUp)
            {
                return "Mockup";
            }
            return Teamserver?.GetConnected().ToString() ?? string.Empty;
        }
    }

    public class CPosition
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Orientation { get; set; }

        public CPosition()
        {
            X = 0f;
            Y = 0f;
            Orientation = 0;
        }

        public CPosition(float x, float y, int orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}