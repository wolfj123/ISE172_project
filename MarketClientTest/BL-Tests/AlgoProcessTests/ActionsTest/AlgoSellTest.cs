using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using System.Collections.Generic;

namespace MarketClientTest
{

    //TODO: sell test
    [TestClass]
    public class AlgoSellTest
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
        public void AlgoSellMethod()
        {

        }


    }
}
