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

        [TestInitialize()]
        public void Initialize()
        {
            //  TODO: Add test initialization code
        }


        //TODO: AskCompareTest
        [TestMethod]
        public void AskCompareTestMethod()
        {
            //Create stub communicator and pass it to the AMA
            int commodity = 0;
            MQCommodity qmarket = new MQCommodity(); qmarket.ask = "10";
            MQCommodityWrapper qmarketWrapper = new MQCommodityWrapper();
            qmarketWrapper.info = qmarket; qmarketWrapper.id = commodity;
            List<MQCommodityWrapper> stubResponse = new List<MQCommodityWrapper>(); stubResponse.Add(qmarketWrapper);

            CommStubStaticReturn comm = new CommStubStaticReturn();
            comm.qAllmarket = stubResponse;
            AdvancedAMA agent = new AdvancedAMA(3+1, 1000, comm);

            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess(agent, comm, commodity);
            testProcess.addCondition(new AlgoAskCompare(11));
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
