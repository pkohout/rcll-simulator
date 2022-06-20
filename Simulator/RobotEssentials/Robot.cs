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
        private TcpConnector? TcpConnection;
        private UdpConnector? UdpConnection;
        private bool Running;
        private Products? HeldProduct;
        private GameState.Types.State GameState;
        private GameState.Types.Phase GamePhase;
        private RobotState RobotState;
        private Zones? CurrentZone;
        private readonly Queue<AgentTask> Tasks;
        public AgentTask? CurrentTask { get; set; }
        private DateTime MoveStart = DateTime.MinValue;
        public List<RobotMachineReportEntry> Machines { get; set; }
        public Thread? WorkingRobotThread { get; set; }
        private RobotManager MyManager;
        public Window? RobotView { get; set; }
        private readonly Configurations Config;
        public string TaskDescription { get; private set; }
        public ManualResetEvent WaitForPrepare { get; private set; }
        private MpsManager? MpsManager;
        public List<FinishedTasks> FinishedTasksList { get; }
        private enum TaskEnum : int
        {
            None,
            Move,
            Deliver,
            Retrieve,
            Buffer,
            Explore
        }

        public Robot(string name, RobotManager manager, Team color, int jersey, bool debug = false)
        {
            Config = Configurations.GetInstance();
            RobotName = name;
            TeamName = Config.Teams[0].Name;
            TeamColor = color;
            Position = new CPosition(5f, 1f, 0);
            MyManager = manager;
            JerseyNumber = (uint)jersey;
            FinishedTasksList = new List<FinishedTasks>();

            MyLogger = new MyLogger(this.JerseyNumber + "_" + this.RobotName, debug);
            MyLogger.Log("--------------------------------------------------------");
            MyLogger.Log(RobotName + " is ready for production!");
            Running = true;
            RobotState = RobotState.Active;
            WaitForPrepare = new ManualResetEvent(false);

            CurrentZone = null;
            Tasks = new Queue<AgentTask>();
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
            return HeldProduct != null;
        }
        public Zones? GetZone()
        {
            return CurrentZone;
        }
        public Products? GetHeldProduct()
        {
            //MyLogger.Log("Checking if a Product is held. Currently = " + (HeldProduct == null ? "null" : HeldProduct.ProductDescription()));
            return HeldProduct;
        }
        public void DropItem()
        {
            MyLogger.Log("Dropping my Product!");
            HeldProduct = null;
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

        public void SetAgentTasks(AgentTask task)
        {
            switch (Config.IgnoreTeamColor)
            {
                case true when CurrentTask != null && task.CancelTask && task.TaskId == CurrentTask.TaskId:
                    MyLogger.Log("Current task should be canceled!");
                    //TODO added canceling of tasks, need to evaluate if behaviour is now correct!
                    CurrentTask.Canceled = true;
                    CurrentTask.Successful = true;
                    if (Config.RobotConnectionType.Equals("udp"))
                    {
                        UdpConnection.AddMessage(UdpConnection.CreateMessage(PBMessageFactoryBase.MessageTypes.AgentTask));
                    }
                    else
                    {
                        
                    }
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

            if (!Config.MockUp)
            {
                if (Config.RobotConnectionType.Equals("udp"))
                {
                    UdpConnection = new UdpConnector(this, MyLogger);
                    UdpConnection.Start();
                }
                else
                {
                    TcpConnection = new TcpConnector(this, MyLogger);
                    TcpConnection?.Start();
                }

            }


            MyLogger.Log("Starting " + RobotName + "'s working thread! Mockup = " +
                         Configurations.GetInstance().MockUp.ToString());
            Work();
            if (Config.RobotConnectionType.Equals("udp"))
            {
                UdpConnection.Stop();
            }
            else
            {

                TcpConnection?.Stop();
            }
        }

        private void AddMessage(PBMessageFactoryBase.MessageTypes type)
        {
            MyLogger.Log("Sending a " + type.ToString() + "!");

            if (Config.RobotConnectionType.Equals("udp"))
            {
                var message = UdpConnection?.CreateMessage(type);
                if (message != Array.Empty<byte>())
                {
                    UdpConnection?.AddMessage(message);
                }
                else
                {
                    MyLogger.Log("No" + type.ToString() + " can be sent!");
                }
            }
            else
            {
                var message = TcpConnection?.CreateMessage(type);
                if (message != Array.Empty<byte>())
                {
                    TcpConnection?.AddMessage(message);
                }
                else
                {
                    MyLogger.Log("No" + type.ToString() + " can be sent!");
                }
            }
        }



    #region BasicBehaviour

    private bool Move(Zone TargetZone)
        {
            var attempt = 0;

            var path = ZonesManager.GetInstance().Astar(CurrentZone, ZonesManager.GetInstance().GetZone(TargetZone));
            if (path.Count == 0 && CurrentZone.ZoneId == TargetZone)
            {
                MyLogger.Log("Finished the move as I'm already in place!");
                return true;
            }
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
            if (CurrentZone.ZoneId != ZonesManager.GetInstance().GetZoneNextToMachine(mps.Name, machinePoint))
            {
                MyLogger.Log("Unable to GRIP, not yet in position!");
                return false;
            }
            MyLogger.Log("At station starting the GRIP Action!");
            TaskDescription = "Grasping Product";
            var attempts = 0;
            while (HeldProduct == null && attempts < 30)
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

        private bool PlaceProduct(Mps mps, string machinePoint = "input", uint shelfNumber = 0)
        {
            if (!mps.EmptyMachinePoint(machinePoint))
            {
                MyLogger.Log("Something went wrong with placing. Seems there is already a product at " + machinePoint + " of machine " + mps.Name);
                return false;
            }
            TaskDescription = "Placing product";
            MyLogger.Log("Aligning and starting the place action");
            Thread.Sleep(Config.RobotPlaceDuration);
            switch (mps.Type)
            {
                case MPS.Mps.MpsType.RingStation:
                    {
                        ((MPS_RS)mps).PlaceProduct(machinePoint, HeldProduct);
                        if (!machinePoint.Equals("slide") && Config.SendPrepare)
                        {
                            AddMessage(PBMessageFactoryBase.MessageTypes.GripsPrepareMachine);
                        }

                        break;
                    }
                case MPS.Mps.MpsType.DeliveryStation:
                    {
                        mps.PlaceProduct(machinePoint, HeldProduct);
                        if (Config.SendPrepare)
                        {
                            AddMessage(PBMessageFactoryBase.MessageTypes.GripsPrepareMachine);
                        }

                        break;
                    }
                default:
                    mps.PlaceProduct(machinePoint, HeldProduct);
                    break;
            }

            HeldProduct = null;
            TaskDescription = "Idle";
            return true;
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
            var Waypoint = CurrentTask.Move.Waypoint;
            var MachinePoint = CurrentTask.Move.MachinePoint;
            Zone targetZone = ZonesManager.GetInstance().GetWaypoint(Waypoint, MachinePoint);
            if (targetZone == 0)
            {
                MyLogger.Log("Couldn't find the machine position!");
                TaskDescription = "Idle";
                CurrentTask.Successful = false;
                AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
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
                AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
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
            var machine = CurrentTask.Retrieve.MachineId;
            MpsManager ??= MpsManager.GetInstance();
            var mps = MpsManager.GetMachineViaId(CurrentTask.Retrieve.MachineId);
            var target = CurrentTask.Retrieve.MachinePoint;
            Zone targetZone = ZonesManager.GetInstance().GetWaypoint(machine, target);
            if (targetZone == 0)
            {
                MyLogger.Log("Couldnt find the requested target machine!");
                if (!Config.MockUp)
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
                    if (Config.SendPrepare)
                    {
                        AddMessage(PBMessageFactoryBase.MessageTypes.GripsPrepareMachine);
                    }

                }
                CurrentTask.Successful = Move(targetZone);
                if (!Configurations.GetInstance().MockUp && !CurrentTask.Successful)
                {
                    MyLogger.Log("Movement was not successful we interrupt the task!");
                    AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
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
                                AddMessage(PBMessageFactoryBase.MessageTypes.GripsPrepareMachine);
                            }
                            break;
                        }
                }
            }
            if (mps == null)
            {
                MyLogger.Log("The Machine was not found? Griping not possible?");
                CurrentTask = null;
                return;
            }
            CurrentTask.Successful = GripProduct(mps, target);
            if (!Configurations.GetInstance().MockUp)
            {
                AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
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
            var machine = CurrentTask.Deliver.MachineId;
            var target = CurrentTask.Deliver.MachinePoint;
            Zone targetZone = ZonesManager.GetInstance().GetWaypoint(machine, target);
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
                    AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
                    return;
                }
            }
            MyLogger.Log("Placing the product on the machine!");
            MpsManager ??= MpsManager.GetInstance();
            var mps = MpsManager.GetMachineViaId(machine);
            CurrentTask.Successful = PlaceProduct(mps, target);
            if (!Config.MockUp)
            {
                AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
            }
            TaskDescription = "Idle";
        }
        private void BufferCapStation()
        {
            MyLogger.Log("BufferCapStation!");
            var machine = CurrentTask?.Buffer.MachineId;
            var target = CurrentTask?.Buffer.ShelfNumber;
            MpsManager ??= MpsManager.GetInstance();
            var mps = MpsManager.GetMachineViaId(machine);
            if (GripProduct(mps, "shelf" + target.ToString()))
            {
                MyLogger.Log("Was able to get a Product from the shelf" + target.ToString());
            }

            MyLogger.Log("Trying to place the currently held Product on the input side of the CS");
            CurrentTask.Successful = PlaceProduct(mps);

            MyLogger.Log("Next we need to send a prepare machine to the teamserver!");
            if (Config.SendPrepare)
            {
                AddMessage(PBMessageFactoryBase.MessageTypes.GripsPrepareMachine);
            }
            if (CurrentTask == null)
            {
                return;
            }
            MyLogger.Log("Buffered the machine " + (CurrentTask.Successful ? "successful" : "unsuccessful") + "!");
            AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
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
            AddMessage(PBMessageFactoryBase.MessageTypes.AgentTask);
        }

        private void Explore()
        {
            MyLogger.Log("Current Zone = " + CurrentZone.ToString());
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

                            if (CurrentTask.PauseTask)
                            {
                                MyLogger.Log("Got a pause robot task [" + CurrentTask.PauseTask.ToString() +
                                             "] --- task is done!");
                            }
                            if (CurrentTask.HasCancelTask)
                            {
                                MyLogger.Log("Got a Cancel Task!");
                            }
                            switch (CheckTaskType())
                            {
                                case TaskEnum.Move:
                                    MoveToWaypoint();
                                    break;
                                case TaskEnum.Retrieve:
                                    GetFromStation();
                                    break;
                                case TaskEnum.Deliver:
                                    DeliverToStation();
                                    break;
                                case TaskEnum.Buffer:
                                    BufferCapStation();
                                    break;
                                case TaskEnum.Explore:
                                    ExploreMachine();
                                    break;
                                case TaskEnum.None:
                                default:
                                    MyLogger.Log("Somehow an empty task was added?");

                                    if (Configurations.GetInstance().IgnoreTeamColor)
                                    {
                                        /*
                                        var message = Teamserver.CreateMessage(PBMessageFactoryBase.MessageTypes.GripsMidlevelTasks);
                                        if(message != null)
                                        {
                                            Teamserver.AddMessage(message);
                                        }
                                        */

                                    }
                                    else
                                    {
                                        if (CurrentTask.TeamColor != TeamColor)
                                        {
                                            MyLogger.Log("Got a task thats not for me. I ignore it!");
                                        }
                                    }
                                    break;
                            }
                            FinishedTasksList.Add(new FinishedTasks(CurrentTask.TaskId, CurrentTask.Successful));
                            CurrentTask = null;
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
                Thread.Sleep(500);
            }
        }
        private TaskEnum CheckTaskType()
        {
            if (CurrentTask.Move != null)
                return TaskEnum.Move;
            else if (CurrentTask.Retrieve != null)
                return TaskEnum.Retrieve;
            else if (CurrentTask.Deliver != null)
                return TaskEnum.Deliver;
            else if (CurrentTask.Buffer != null)
                return TaskEnum.Buffer;
            else if (CurrentTask.ExploreMachine != null)
                return TaskEnum.Explore;
            else
                return TaskEnum.None;
        }

        public void TestMove()
        {
            AgentTask task = new AgentTask()
            {
                RobotId = 0,
                TaskId = 1,
                TeamColor = TeamColor,
                Move = new Move
                {
                    Waypoint = "C_Z11"
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
            var format = "Task {0} finished {1}\n";
            return FinishedTasksList.Aggregate("", (current, task) => current + String.Format(format, task.TaskId, task.Successful ? "successful" : "unsuccessful"));
            //return MyLogger.GetLines(lines);
        }
        public string GetConnectionState()
        {
            if (Configurations.GetInstance().MockUp)
            {
                return "Mockup";
            }

            if (Config.RobotConnectionType.Equals("tcp"))
            {
                return TcpConnection.GetConnected().ToString() ?? string.Empty;
            }
            else
            {
                return "UDP";
            }

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

    public class FinishedTasks
    {
        public uint TaskId { get; }
        public bool Successful { get; }

        public FinishedTasks(uint taskid, bool success)
        {
            TaskId = taskid;
            Successful = success;
        }
    }
}