using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class BidCompareTest
    {
        //TODO: BidCompareTest
        [TestMethod]
        public void BidCompareTestMethod()
        {
            MQCommodity qmarket = new MQCommodity();
            qmarket.bid = "10";
            ICommunicator comm = new CommStubStaticReturn(null, null, null, null, qmarket, null, null, null);
            AdvancedAMA agent = new AdvancedAMA(1, 1000, comm);

            AlgoCountProcess testProcess = new AlgoCountProcess();
            testProcess.addCondition(new AlgoBidCompare(9));

            agent.enable(true); agent.enable(false);

            Assert.AreEqual(1, testProcess.count);
        }
    }
}
