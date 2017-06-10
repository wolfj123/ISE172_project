using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class BuyProcessFullStepsTest
    {

        [TestMethod]
        public void BuyTestFullProcess()
        {
            //arrange
            MBuySell buy = new MBuySell(); buy.id = "666";
            MQReq query = new MQReq();
            MQCommodity market = new MQCommodity(); market.ask = "1";
            MarketException excp = new MarketException();

            CommStubStaticReturn comm = new CommStubStaticReturn(buy,
                null, null, excp, market, null, null, null);
            BuyProcess testProcess = new BuyProcess(true, comm, 1, 1, 1, 1);

            //initial assert
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //act1
            object output = testProcess.run();

            //assert1
            Assert.AreEqual(testProcess.currIndex, 1);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //act2
            output = testProcess.run();

            //assert2
            Assert.AreEqual(testProcess.currIndex, 2);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //update communicator stub
            comm = new CommStubStaticReturn(buy,
                null, null, query, market, null,null, null);
            testProcess.comm = comm;

            //act3
            output = testProcess.run();

            //assert3
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.queue, LogicQueue.last);

            //act4
            output = testProcess.run();

            //assert4
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.queue, LogicQueue.last);
        }

    }
}
