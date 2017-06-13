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
            int interval = 2000;
            int multiplier = 2;

            AlgoCountProcess testLogic = new AlgoCountProcess();
            AdvancedAMA amaTest = new AdvancedAMA(maxReq, interval, new CommStubStaticReturn());
            amaTest.add(testLogic);
            amaTest.enable(true);

            //multiplier+1 because the ama waits the interval once enabled 
            //to run the first time
            System.Threading.Thread.Sleep(interval * (multiplier+1));
            amaTest.enable(false);

            Task.WaitAll();
            Assert.AreEqual(maxReq * multiplier, testLogic.count);
        }
    }
}
