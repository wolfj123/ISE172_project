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
            LogicBlock testLogic = new PrintLogic();
            AMA amaTest = new AMA(10, 10000);
            amaTest.add(testLogic);
            amaTest.enable(true);

            System.Threading.Thread.Sleep(10000);
            amaTest.enable(false);
        }

    }


    public class PrintLogic : LogicBlock
    {
        public PrintLogic()
        {
            setRepeat(true);
        }
        public override object run()
        {
            Trace.WriteLine("test");
            return null;
        }
    }

}
