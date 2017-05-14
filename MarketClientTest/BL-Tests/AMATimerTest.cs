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
    public class AMATimerTest
    {
        [TestMethod]
        public void TestTimer()
        {
            //setup
            int maxReq = 10;
            int interval = 2000;

            CountLogic testLogic = new CountLogic();
            AMA amaTest = new AMA(maxReq, interval);
            amaTest.add(testLogic);
            amaTest.enable(true);

            System.Threading.Thread.Sleep(interval);
            amaTest.enable(false);

            Assert.AreEqual(maxReq, testLogic.count);
        }

    }

    //LogicProcess Stub
    public class CountLogic : LogicProcess
    {
        public int count;
        public CountLogic()
            : base(true, null, 0, 0, 0, 0)
        {
            count = 0;
        }

        public override LogicProcess run()
        {
            Trace.WriteLine("Current Count is: "+count + " Time is: " +DateTime.Now);
            count = count + 1;
            return null;
        }
    }
}
