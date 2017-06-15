using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using System.Collections.Generic;
using MarketClient.DataEntries;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class MomentumDecreaseTest
    {
        int commodity;
        CommStubStaticReturn comm;
        AdvancedAMA agent;

        [TestInitialize]
        public void TestInitialize()
        {
            //Create stub communicator and pass it to the AMA
            commodity = 0;
            comm = new CommStubStaticReturn();
            agent = new AdvancedAMA(3 + 1, 1000, comm);
        }

        [TestMethod]
        public void MomentumDecreaseTrue()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            SQL_DAL_implementation sqlStub = new SQLserverMomentumStub(false);
            MomentumDecrease momentumDecreaseCond = new MomentumDecrease(1, 10, 20); momentumDecreaseCond.sql = sqlStub;
            testProcess.addCondition(momentumDecreaseCond);
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(1500);
            agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(1, testProcess.count);
        }

        [TestMethod]
        public void MomentumDecreaseFalse()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            SQL_DAL_implementation sqlStub = new SQLserverMomentumStub(false);
            MomentumDecrease momentumDecreaseCond = new MomentumDecrease(20, 10, 1); momentumDecreaseCond.sql = sqlStub;
            testProcess.addCondition(momentumDecreaseCond);
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(1500);
            agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(0, testProcess.count);
        }
    }
}
