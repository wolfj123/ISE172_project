using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using System.Collections.Generic;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class BidCompareTest
    {
        //TODO: Bid compare
        [TestMethod]
        public void BidCompareTestMethod()
        {
            //Create stub communicator and pass it to the AMA
            int commodity = 0;
            MQCommodity qmarket = new MQCommodity(); qmarket.bid = "10";
            MQCommodityWrapper qmarketWrapper = new MQCommodityWrapper();
            qmarketWrapper.info = qmarket; qmarketWrapper.id = commodity;
            List<MQCommodityWrapper> stubResponse = new List<MQCommodityWrapper>(); stubResponse.Add(qmarketWrapper);

            CommStubStaticReturn comm = new CommStubStaticReturn();
            comm.qAllmarket = stubResponse;
            AdvancedAMA agent = new AdvancedAMA(3 + 1, 1000, comm);

            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new AlgoBidCompare(11));
            agent.add(testProcess);

            //Run AMA once
            agent.enable(true);
            System.Threading.Thread.Sleep(999);
            agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(1, testProcess.count);
        }
    }
}
