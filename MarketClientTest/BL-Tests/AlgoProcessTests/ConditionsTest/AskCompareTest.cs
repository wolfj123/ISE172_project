using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using System.Collections.Generic;

namespace MarketClientTest
{
    [TestClass]
    public class AskCompareTest
    {
        int commodity;
        CommStubStaticReturn comm;
        AdvancedAMA agent;

        [TestInitialize]
        public void TestInitialize()
        {
            //Create stub communicator and pass it to the AMA
            commodity = 0;
            MQCommodity qmarket = new MQCommodity(); qmarket.ask = "10";
            MQCommodityWrapper qmarketWrapper = new MQCommodityWrapper();
            qmarketWrapper.info = qmarket; qmarketWrapper.id = commodity;
            List<MQCommodityWrapper> stubResponse = new List<MQCommodityWrapper>(); stubResponse.Add(qmarketWrapper);

            comm = new CommStubStaticReturn();
            comm.qAllmarket = stubResponse;
            agent = new AdvancedAMA(3 + 1, 1000, comm);
        }

        [TestMethod]
        public void AskCompareTestTrue()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new AlgoAskCompare(10 + 1));
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(1500);
            agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(1, testProcess.count);
        }

        [TestMethod]
        public void AskCompareTestFalse()
        {
            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new AlgoAskCompare(10 - 1));
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
