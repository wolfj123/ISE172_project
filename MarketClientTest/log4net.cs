using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient;
using MarketClient.Utils;
using System.Collections.Generic;
using log4net;

namespace MarketClientTest
{
    [TestClass]
     public class log4net
    {
        private static ILog myLogger = LogManager.GetLogger("testLog");

        [TestMethod]
        public void TestlogLevel()
        {
            myLogger.Fatal("this is a fatal msg");
            myLogger.Info("this is a info msg");
            myLogger.Debug("this is debug");
            Console.WriteLine("sucssed");  

        }

    }
}
