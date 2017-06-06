using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;

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
            MQCommodity qmarket = new MQCommodity();
            qmarket.ask = "10";
            ICommunicator comm = new CommStubStaticReturn(null, null, null, null, qmarket, null,null,null);
            AdvancedAMA agent = new AdvancedAMA(1, 1000, comm);

            //Create process that will count each time the AlgoAskCompare condition is "true"
            AlgoCountProcess testProcess = new AlgoCountProcess();
            testProcess.addCondition(new AlgoAskCompare(11));

            //Run AMA once
            agent.enable(true); agent.enable(false);

            //AMA ran once - count should be "1"
            Assert.AreEqual(1, testProcess.count);
        }
    }
}
