using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using MarketClient.Utils;
using System.Collections.Generic;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class SellProcessHasExistingRequestTest
    {
        [TestMethod]
        public void SellTestHasExisitingRequest()
        {
            //arrange
            MQReq query = new MQReq();
            CommStubStaticReturn comm = new CommStubStaticReturn(null,
                null, null, query, null, null);
            SellProcess testProcess = new SellProcess(false, comm, 1, 1, 1, 1);

            //initial assert
            Assert.AreEqual(testProcess.currIndex, 0);
            Assert.AreEqual(testProcess.repeat, false);
            Assert.AreEqual(testProcess.queue, LogicQueue.first);

            //act
            object output = testProcess.run();

            //assert
            Assert.AreEqual(testProcess.repeat, false);
            Assert.AreEqual(testProcess.queue, LogicQueue.last);
            Assert.IsInstanceOfType(output, typeof(LogicProcess));
            Assert.AreEqual(testProcess.currIndex, 0);
        }

        
    }
}
