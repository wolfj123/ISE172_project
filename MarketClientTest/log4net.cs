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
    class log4net
    {
        [TestMethod]
        public void TestlogLevel()
        {
            ILog myLogger = LogManager.GetLogger("fileLogger");
            myLogger.Fatal("this is a fatal msg");
            myLogger.Info("this is a info msg");
            myLogger.Debug("this is debug");
            Console.WriteLine("sucssed");
        }
        


    }
}
