using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using System.Collections.Generic;
using MarketClient.DataEntries;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class MomentumIncreaseTest
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


        //TODO: MomentumIncreaseTest
        [TestMethod]
        public void MomentumIncreaseTrue()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            SQL_DAL_implementation sqlStub = new SQLserverMomentumStub(true);
            MomentumIncrease momentumIncreaseCond = new MomentumIncrease(1, 10, 100); momentumIncreaseCond.sql = sqlStub;
            testProcess.addCondition(momentumIncreaseCond);
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(1500);
            agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(1, testProcess.count);
        }

        [TestMethod]
        public void MomentumIncreaseFalse()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new AlgoBidCompare(10 + 1));
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(1500);
            agent.enable(false);

            //AMA ran once but condition is not met - count should be "0"
            Assert.AreEqual(0, testProcess.count);
        }
    }
}
