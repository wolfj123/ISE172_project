using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using System.Collections.Generic;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class HasNoActiveRequestTest
    {
        int commodity;
        CommStubStaticReturn comm;
        MQReqWrapper qmarketWrapper;
        AdvancedAMA agent;

        [TestInitialize]
        public void TestInitialize()
        {
            //Create stub communicator and pass it to the AMA
            commodity = 0;
            
            MQReq qmarket = new MQReq();
            qmarketWrapper = new MQReqWrapper(); qmarketWrapper.id = 123456;
            qmarketWrapper.request = qmarket; 
            List<MQReqWrapper> stubResponse = new List<MQReqWrapper>(); stubResponse.Add(qmarketWrapper);

            comm = new CommStubStaticReturn();
            comm.qAllrequests = stubResponse;
            agent = new AdvancedAMA(3 + 1, 1000, comm);
        }

        [TestMethod]
        public void HasNoActiveRequestTestTrue()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new HasNoActiveRequest());
            testProcess.requestID = -1;
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(999);
            agent.enable(false);

            //AMA ran once but condition is not met - count should be "0"
            Assert.AreEqual(1, testProcess.count);
        }

        [TestMethod]
        public void HasNoActiveRequestTestFalse()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new HasNoActiveRequest());
            testProcess.requestID = qmarketWrapper.id;
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(999);
            agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(0, testProcess.count);
        }
    }
}
