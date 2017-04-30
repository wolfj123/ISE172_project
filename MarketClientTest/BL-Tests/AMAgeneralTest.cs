using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;
using log4net;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class AMAgeneralTest
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");


        [TestMethod]
        public void TestMethod1()
        {
            AMA testAMA = new DefaultAMA();
            testAMA.enable(true);

        }
    }
}
