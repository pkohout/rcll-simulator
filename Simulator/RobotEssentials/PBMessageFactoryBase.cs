﻿using System;
using System.Collections.Generic;
using Google.Protobuf;
using Llsfmsgs;
using LlsfMsgs;
using MachineStates;
using Simulator.Utility;
using Team = LlsfMsgs.Team;
using Timer = Simulator.Utility.Timer;

namespace Simulator.RobotEssentials
{
    class PBMessageFactoryBase
    {
        private readonly Robot? Peer;
        private ulong SequenzNr;
        private Timer? Timer;
        private readonly MyLogger MyLogger;
        public enum MessageTypes
        {
            BeaconSignal, // Sending periodcally to detect refbox and robots
            RobotInfo,
            ReportAllMachines,
            MachineOrientation,
            PrsTask,
            PrepareMachine,
            SimulationTime,
            GripsPrepareMachine,
            GripsBeaconSignal,
            AgentTask,
            SimSynchTime,
            ExplorationInfo, //send from the refbox to the robot
            GameState, // send from the refbox to the robot
            MachineInfo, // Get send from the refbox to the robot in production to update information for the robot
            OrderInfo, // gets periodically sent from the refbox to update the current open orders
            MachineReport //Sending message to the Refbox
        }



        public PBMessageFactoryBase(MyLogger log)
        {
            SequenzNr = 0;
            MyLogger = log;
            Timer = null;
        }

        public byte[]? CreateMessage(MessageTypes mtype)
        {
            Timer ??= Timer.GetInstance();
            ushort cmp = 0;
            ushort msg = 0;
            uint payloadsize = 0;
            byte[] bytes;
            var time = new Time();
            // Insert the Time for Message-Types Beacon,Robot,Machine
            if (mtype is MessageTypes.RobotInfo or MessageTypes.MachineReport)
            {
                time.Nsec = Timer.Nsec;
                time.Sec = Timer.Sec;
            }
            MyLogger.Log("Creating a : " + mtype + " message!");
            switch (mtype)
            {
                case MessageTypes.BeaconSignal:
                    {
                        var Signal = new BeaconSignal();
                        Signal = CreateBeaconSignal();
                        cmp = (ushort)BeaconSignal.Types.CompType.CompId;
                        msg = (ushort)BeaconSignal.Types.CompType.MsgType;
                        payloadsize = (uint)Signal.CalculateSize() + 4;
                        bytes = Signal.ToByteArray();
                        break;
                    }
                case MessageTypes.GripsBeaconSignal:
                    {
                        var Signal = new GripsBeaconSignal();
                        var bs = CreateBeaconSignal();
                        Signal.BeaconSignal = bs;
                        cmp = (ushort)GripsBeaconSignal.Types.CompType.CompId;
                        msg = (ushort)GripsBeaconSignal.Types.CompType.MsgType;
                        payloadsize = (uint)Signal.CalculateSize() + 4;
                        bytes = Signal.ToByteArray();
                        break;
                    }
                case MessageTypes.PrepareMachine:
                case MessageTypes.GripsPrepareMachine:
                    var machineId = "";
                    var machinePoint = "";
                    if (Peer is { CurrentTask: { } })
                    {
                        var robotId = Peer.JerseyNumber;
                        if(Peer.CurrentTask.Deliver != null)
                        {
                            machineId = Peer.CurrentTask.Deliver.MachineId;
                            machinePoint = Peer.CurrentTask.Deliver.MachinePoint;
                        }
                        else if(Peer.CurrentTask.Buffer != null)
                        {
                            machineId = Peer.CurrentTask.Buffer.MachineId;
                            machinePoint = "input"; // Peer.CurrentTask.BufferCapStation.ShelfNumber.ToString();
                        }
                        else if (Peer.CurrentTask.Retrieve != null)
                        {
                            machineId = Peer.CurrentTask.Retrieve.MachineId;
                            machinePoint = Peer.CurrentTask.Retrieve.MachinePoint;
                        }
                        var machine = new GripsPrepareMachine()
                        {
                            RobotId = robotId,
                            MachineId = machineId,
                            MachinePoint = machinePoint,
                            MachinePrepared = true
                        };
                        cmp = (ushort)GripsPrepareMachine.Types.CompType.CompId;
                        msg = (ushort)GripsPrepareMachine.Types.CompType.MsgType;
                        payloadsize = (uint)machine.CalculateSize() + 4;
                        bytes = machine.ToByteArray();
                        MyLogger.Log("Created a prepare machine message!");
                        MyLogger.Log(machine.ToString());
                        break;
                    }
                    MyLogger.Log("Cant't create the GripPrepareMachineTask as the Peer is not set or there is no task");
                    return null;
                case MessageTypes.SimSynchTime:
                    var simtime = new SimTimeSync
                    {
                        Paused = Timer.Paused,
                        RealTimeFactor = Timer.TimeFactor,
                        SimTime = GetTimeMessage()
                    };
                    cmp = (ushort)SimTimeSync.Types.CompType.CompId;
                    msg = (ushort)SimTimeSync.Types.CompType.MsgType;
                    payloadsize = (uint)simtime.CalculateSize() + 4;
                    bytes = simtime.ToByteArray();
                    // MyLogger.Log("Created message = " + simtime.ToString());
                    //Configurations.GetInstance().Time;
                    break;
                case MessageTypes.GameState:
                    var gamestate = new GameState()
                    {
                        GameTime = GetTimeMessage(),
                        Phase = GameState.Types.Phase.Exploration,
                        PointsCyan = 0,
                        PointsMagenta = 0,
                        State = GameState.Types.State.Init,
                        TeamCyan = Configurations.GetInstance().Teams[0].Name,
                        TeamMagenta = Configurations.GetInstance().Teams[1].Name,
                    };
                    cmp = (ushort)GameState.Types.CompType.CompId;
                    msg = (ushort)GameState.Types.CompType.MsgType;
                    payloadsize = (uint)gamestate.CalculateSize() + 4;
                    bytes = gamestate.ToByteArray();
                    break;
                case MessageTypes.AgentTask:
                    if(Peer == null)
                    {
                        return null;
                    }
                    var answer = new AgentTask()
                    {
                        TeamColor = Peer.TeamColor,
                        TaskId = Peer.CurrentTask.TaskId,
                        RobotId = Peer.JerseyNumber,
                        Move = Peer.CurrentTask.Move,
                        Retrieve = Peer.CurrentTask.Retrieve,
                        Deliver = Peer.CurrentTask.Deliver,
                        Buffer = Peer.CurrentTask.Buffer,
                        ExploreMachine = Peer.CurrentTask.ExploreMachine,
                        CancelTask = Peer.CurrentTask.CancelTask,
                        PauseTask = Peer.CurrentTask.PauseTask,
                        Successful = Peer.CurrentTask.Successful,
                        Canceled = Peer.CurrentTask.Canceled
                    };
                    cmp = (ushort)AgentTask.Types.CompType.CompId;
                    msg = (ushort)AgentTask.Types.CompType.MsgType;
                    payloadsize = (uint)answer.CalculateSize() + 4;
                    bytes = answer.ToByteArray();
                    MyLogger.Log("The Created AgentTask = " + answer.ToString());
                    break;
                default:
                    return null;
            }
            var fh = new FrameHeader(payloadsize);
            var mh = new MessageHeader(cmp, msg);
            var mb = new MessageBody(bytes);
            var message = new Message(fh, mh, mb);
            return message.GetBytes();
        }

        private BeaconSignal CreateBeaconSignal()
        {
            var bs = new BeaconSignal
            {
                Time = GetTimeMessage(),
                TeamColor = Peer?.TeamColor ?? Configurations.GetInstance().Teams[0].Color,
                Number = Peer?.JerseyNumber ?? 0
            };
            var pose = GetPose2DMessage();
            bs.TeamName = Peer?.TeamName ?? Configurations.GetInstance().Teams[0].Name;
            bs.PeerName = Peer?.RobotName ?? "Client";
            bs.Seq = ++SequenzNr;
            bs.Number = Peer?.JerseyNumber ?? 0;
            bs.Pose = pose;
            bs.FinishedTasks.Clear();
            bs.Task = Peer?.CurrentTask;
            if(Peer != null && Peer.FinishedTasksList.Count != 0)
            {
                foreach( var t in Peer.FinishedTasksList)
                {
                    var task = new FinishedTask{
                        TaskId = t.TaskId,
                        Successful = t.Successful
                    };
                    bs.FinishedTasks.Add(task);
                }
            }
            //MyLogger.Log(bs.ToString());
            return bs;
        }
        public Time GetTimeMessage()
        {
            Timer ??= Timer.GetInstance();
            return Timer.GetTime();
        }

        public Pose2D GetPose2DMessage()
        {
            return new Pose2D
            {
                X = Peer?.Position.X ?? 0,
                Y = Peer?.Position.Y ?? 0,
                Ori = Peer?.Position.Orientation ?? 0,
                Timestamp = GetTimeMessage()
            };
        }
    }

    class Message
    {
        readonly byte[] Bytes;
        FrameHeader framehead;
        MessageHeader messagehead;
        MessageBody messagebody;

        public Message(FrameHeader fh, MessageHeader mh, MessageBody mb)
        {
            framehead = fh;
            messagehead = mh;
            messagebody = mb;
            var length = fh.GetBytes().Length + mh.GetBytes().Length + mb.GetBytes().Length;
            Bytes = new byte[length];
            Buffer.BlockCopy(framehead.GetBytes(), 0, Bytes, 0, framehead.Length);
            Buffer.BlockCopy(messagehead.GetBytes(), 0, Bytes, framehead.Length, messagehead.Length);
            Buffer.BlockCopy(messagebody.GetBytes(), 0, Bytes, framehead.Length + messagehead.Length, messagebody.Length);
            //PrintBytes(Bytes);
        }

        public byte[] GetBytes()
        {
            return Bytes;
        }

        private void PrintBytes(IEnumerable<byte> toPrint)
        {
            Console.WriteLine("Printing Bytes = ");
            foreach (var b in toPrint)
            {
                Console.Write("\\x{0}", b.ToString().PadLeft(2, '0'));
            }
            Console.WriteLine("");
        }

    }

    class FrameHeader
    {
        public static byte Version = 2;
        public static byte Cipher = 0;
        public static byte Reserved = 0;
        public static byte Reserved2 = 0;
        byte[] Bytes;
        public int Length;
        public FrameHeader(uint payload)
        {
            Bytes = new byte[8];
            Bytes[0] = Version;
            Bytes[1] = Cipher;
            Bytes[2] = Reserved;
            Bytes[3] = Reserved2;
            var payloadbytes = GetBytesfrom32(payload);
            Bytes[4] = payloadbytes[3];
            Bytes[5] = payloadbytes[2];
            Bytes[6] = payloadbytes[1];
            Bytes[7] = payloadbytes[0];
            Length = Bytes.Length;
        }
        public byte[] GetBytes()
        {
            return Bytes;
        }
        public byte[] GetBytesfrom32(uint val)
        {
            var res = new byte[4];
            res[0] = (byte)(val & 0xff);
            res[1] = (byte)((val >> 8) & 0xff);
            res[2] = (byte)((val >> 16) & 0xff);
            res[3] = (byte)((val >> 24) & 0xff);
            return res;
        }
    }

    class MessageBody
    {
        byte[] Bytes;
        public int Length;
        public MessageBody(byte[] bytearray)
        {
            Bytes = bytearray;
            Length = Bytes.Length;
        }
        public byte[] GetBytes()
        {
            return Bytes;
        }
    }

    class MessageHeader
    {
        byte[] Bytes;
        public int Length;
        public MessageHeader(ushort cmp, ushort msg)
        {
            Bytes = new byte[4];
            var cmpBytes = GetBytesfrom16(cmp);
            var msgBytes = GetBytesfrom16(msg);
            Bytes[0] = cmpBytes[0];
            Bytes[1] = cmpBytes[1];
            Bytes[2] = msgBytes[0];
            Bytes[3] = msgBytes[1];
            Length = Bytes.Length;
        }
        public byte[] GetBytesfrom16(ushort val)
        {
            //changed order to fix some bug
            var res = new byte[2];
            res[0] = (byte)(val >> 8);
            res[1] = (byte)(val & 0xff);
            return res;
        }
        public byte[] GetBytes()
        {
            return Bytes;
        }
    }
}
