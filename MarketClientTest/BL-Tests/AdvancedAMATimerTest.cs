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
            int amaUpdateCost = 3;
            int interval = 1000;

            AdvancedAMA amaTest = new AdvancedAMA(maxReq, interval, new CommStubStaticReturn());
            AlgoCountProcess testLogic = new AlgoCountProcess(amaTest, new CommStubStaticReturn(),0);
            amaTest.add(testLogic);
            amaTest.enable(true);

            //interval*2 because the ama waits the interval once enabled 
            //to run the first time
            System.Threading.Thread.Sleep(interval*2);

            amaTest.enable(false);

            Task.WaitAll();
            Assert.AreEqual(maxReq-amaUpdateCost, testLogic.count);
        }
    }
}
