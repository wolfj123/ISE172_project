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

            PrintLogic testLogic = new PrintLogic();
            AMA amaTest = new AMA(maxReq, interval);
            amaTest.add(testLogic);
            amaTest.enable(true);

            System.Threading.Thread.Sleep(interval);
            amaTest.enable(false);

            Assert.AreEqual(maxReq, testLogic.count);
        }

    }

    //LogicProcess Stub
    public class PrintLogic : LogicProcess
    {
        public int count;
        public PrintLogic() 
            : base(true, null, 0, 0, 0, 0)
        {
            count = 0;
        }

        public new LogicProcess run()
        {
            count = count + 1;
            return null;
        }
    }

}
