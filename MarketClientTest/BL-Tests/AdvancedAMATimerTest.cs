using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;

namespace MarketClientTest
{
    
    [TestClass]
    public class AdvancedAMATimerTest
    {
        [TestMethod]
        public void TestAdvancedAMATimer()
        {
            //setup
            int maxReq = 10;
            int interval = 6000;
            int multiplier = 2;

            AlgoCountProcess testLogic = new AlgoCountProcess();
            AdvancedAMA amaTest = new AdvancedAMA(maxReq, interval, new CommStubStaticReturn());
            amaTest.add(testLogic);
            amaTest.enable(true);

            System.Threading.Thread.Sleep(interval * multiplier);
            amaTest.enable(false);

            Assert.AreEqual(maxReq * multiplier, testLogic.count);
        }
    }
}
