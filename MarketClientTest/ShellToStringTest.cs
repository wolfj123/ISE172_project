using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient;
using MarketClient.Utils;
using System.Collections.Generic;

namespace MarketClientTest
{
    [TestClass]
    public class ShellToStringTest
    {
        [TestMethod]
        public void TestDictionaryString()
        {
            Dictionary<String, int> myDict = new Dictionary<String, int>();
            myDict.Add("1", 10);
            myDict.Add("2", 20);
            myDict.Add("3", 30);
            myDict.Add("0", 40);

            Console.WriteLine(Shell.DictionaryToString(myDict));

        }
        

    }
}
