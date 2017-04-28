using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class BuyProcessTest
    {
        [TestMethod]
        public void TestHasExisitingRequest()
        {
            //arrange
            MQReq query = new MQReq();
            CommStubStaticReturn comm = new CommStubStaticReturn(null, 
                null, null, query, null, null);
            BuyProcess testProcess = new BuyProcess(false, comm, 1, 1, 1, 1);

            //initial assert
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.repeat, false);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //act
            object output = testProcess.run();

            //assert
            Assert.AreEqual(testProcess.repeat, false);
            Assert.AreEqual(testProcess.queue, LogicQueue.last);
            Assert.IsInstanceOfType(output, typeof(BuyProcess));
            Assert.AreEqual(testProcess.currIndex, 0);
        }

        [TestMethod]
        public void TestFullProcess()
        {
            //arrange
            MBuySell buy = new MBuySell(); buy.id = "666";
            MQReq query = new MQReq();
            MQCommodity market = new MQCommodity(); market.bid = "1";
            MarketException excp = new MarketException();

            CommStubStaticReturn comm = new CommStubStaticReturn(buy,
                null, null, excp, market, null);
            BuyProcess testProcess = new BuyProcess(true, comm, 1, 1, 1, 1);

            //initial assert
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //act1
            object output = testProcess.run();

            //assert1
            Assert.AreEqual(testProcess.currIndex, 1);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //update communicator stub
            comm = new CommStubStaticReturn(buy,
                null, null, query, market, null);
            testProcess.comm = comm;

            //act2
            output = testProcess.run();

            //assert2
            Assert.AreEqual(testProcess.currIndex, 2);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

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
