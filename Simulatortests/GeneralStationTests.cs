﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulator.MPS;
using LlsfMsgs;
using System.Threading;
using Simulator;
using Simulator.Utility;
using Opc.UaFx.Client;

namespace Simulatortests
{
    [TestClass]
    public class GeneralStationTests
    {
        [TestMethod]
        public void ResetMachine()
        {
            var config = new Configurations();
            var machine = new MPS_BS(config, "C-BS", 5001, 0, Team.Cyan, true);
            var thread = new Thread(machine.Run);
            thread.Start();
            Thread.Sleep(500);
            var testnode = machine.InNodes.ActionId;
            testnode.Value = 10;
            Assert.AreNotEqual(testnode.Value, 0);
            machine.ResetMachine();
            Thread.Sleep(1400);
            Assert.AreEqual(testnode.Value, 0);
        }

        [TestMethod]
        public void BeltTest1()
        {
            var config = new Configurations();
            var machine = new MPS_BS(config, "C-BS", 5002, 0, Team.Cyan, true);
            var thread = new Thread(machine.Run);
            var product = new Products(CapColor.CapBlack);
            thread.Start();
            Thread.Sleep(500);
            machine.InNodes.Data0.Value = 1;
            machine.DispenseBase();
            Thread.Sleep(config.BSTaskDuration + 100);
            Assert.IsNotNull(machine.ProductOnBelt);

            machine.InNodes.Data0.Value = (ushort)Positions.Out;
            machine.InNodes.Data1.Value = (ushort)Direction.FromInToOut;
            machine.HandleBelt();
            Thread.Sleep(config.BeltActionDuration + 100);
            Assert.IsNotNull(machine.ProductAtOut);
            Assert.IsNull(machine.ProductOnBelt);
        }

        [TestMethod]
        public void OPC_Connection()
        {
            // Testing the opc connection generally
            var port = 5003;
            var config = new Configurations();
            var machine = new MPS_BS(config, "C-BS", port, 0, Team.Cyan, true);
            var thread = new Thread(machine.Run);
            var product = new Products(CapColor.CapBlack);
            thread.Start();
            Thread.Sleep(500);
            var value = true;
            var bs = new OPCTestHelper(port);
            if (!bs.CreateConnection())
                Assert.Fail();
            bs.EnableTask();
            Assert.AreEqual(machine.InNodes.StatusNodes.enable.Value, value);
            bs.CloseConnection();
        }

        [TestMethod]
        public void OPC_ResetMachine()
        {
            var port = 5004;
            var config = new Configurations();
            var machine = new MPS_BS(config, "C-BS", port, 0, Team.Cyan, true);
            var thread = new Thread(machine.Run);
            thread.Start();
            Thread.Sleep(500);
            var testnode = machine.InNodes.ActionId;
            var testhelper = new OPCTestHelper(port);
            if (!testhelper.CreateConnection())
                Assert.Fail();
            testhelper.SendTask((ushort)200);
            Assert.AreEqual(200,testnode.Value);
            testhelper.SendTask((ushort)MPS_BS.BaseSpecificActions.Reset);
            Assert.AreEqual(100 ,testnode.Value);
            Thread.Sleep(1400);
            Assert.AreEqual(testnode.Value, 0);
            testhelper.CloseConnection();
        }


        [TestMethod]
        public void OPC_SendTaskTwice()
        {
            var port = 5005;
            var config = new Configurations();
            var machine = new MPS_BS(config, "C-BS", port, 0, Team.Cyan, true);
            var thread = new Thread(machine.Run);
            thread.Start();
            Thread.Sleep(500);
            var testnode = machine.InNodes.ActionId;
            var testhelper = new OPCTestHelper(port);
            if (!testhelper.CreateConnection())
                Assert.Fail();
            testhelper.SendTask((ushort)200);
            Assert.AreEqual(200, testnode.Value);
            testhelper.SendTask((ushort)MPS_BS.BaseSpecificActions.Reset);
            Assert.AreEqual(100, testnode.Value);
            testhelper.SendTask((ushort)MPS_BS.BaseSpecificActions.Reset);
            Thread.Sleep(1400);
            Assert.AreEqual(testnode.Value, 0);
            testhelper.CloseConnection();
        }
    }
}
