using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using MarketClient.Utils;
using System.Collections.Generic;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class SellProcessFullStepsTest
    {
        [TestMethod]
        public void SellTestFullProcess()
        {
            //arrange
            MBuySell sell = new MBuySell(); sell.id = "666";
            MQReq query = new MQReq();
            MQCommodity market = new MQCommodity(); market.bid = "1";
            MarketException excp = new MarketException();

            //create valid user query response
            MQUser user = new MQUser();
            user.commodities = new Dictionary<String, int>();
            user.commodities.Add("1", 3);

            int test = user.commodities["1"];

            CommStubStaticReturn comm = new CommStubStaticReturn(null,
                sell, null, excp, market, user);
            SellProcess testProcess = new SellProcess(true, comm, 1, 1, 1, 1);

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

            //act3
            output = testProcess.run();

            //assert3
            Assert.AreEqual(testProcess.currIndex, 3);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //act4
            output = testProcess.run();

            //assert4
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.queue, LogicQueue.last);

            //update communicator stub
            comm = new CommStubStaticReturn(null,
                sell, null, query, market, user);
            testProcess.comm = comm;


            //act5
            output = testProcess.run();

            //assert5
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.queue, LogicQueue.last);
        }
    }
}
