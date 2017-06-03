using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;

namespace MarketClientTest
{
    [TestClass]
    public class AskCompareTest
    {
        //TODO: AskCompareTest
        [TestMethod]
        public void TestMethod1()
        {

            int commodity = 0;
            MQCommodity qmarket = new MQCommodity();
            qmarket.ask = "10";
            ICommunicator comm = new CommStubStaticReturn(null, null, null, null, qmarket, null);
            AdvancedAMA agent = new AdvancedAMA(1, 1000, comm);

            AlgoProcess process = new AlgoProcess(agent, comm, commodity);
            process.addCondition(new AlgoAskCompare(11));





        }
    }
}
