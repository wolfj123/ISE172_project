using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient;
using MarketClient.Utils;
using System.Collections.Generic;

namespace MarketClientTest
{
    [TestClass]
    public class ShellTests
    {
        [TestMethod]
        public void TestDictionaryString()
        {
            Dictionary<String, int> myDict = new Dictionary<String, int>();
            myDict.Add("1", 10);
            myDict.Add("2", 20);
            myDict.Add("3", 30);
            myDict.Add("0", 40);

            Assert.AreEqual("{1: 10}, {2: 20}, {3: 30}, {0: 40}", Shell.DictionaryToString(myDict));
        }

        [TestMethod]
        public void TestListString()
        {
            List<String> myList = new List<String>();

            myList.Add("4");
            myList.Add("3");
            myList.Add("1");
            myList.Add("2");
            myList.Add("1243");
            
            Assert.AreEqual("4, 3, 1, 2, 1243", Shell.StringListToString(myList));

        }


        [TestMethod]
        public void TestIsNumeric()
        {
            String str1 = "1098765432";
            String str2 = "123.6454";
            String str3 = "222 3";
            String str4 = "asd21";
            String str5 = " ";
            String str6 = "+";


            String[] arr = new String[] { "112312asasas", "222 3", "1" };

            Assert.AreEqual(true, Shell.isNumeric(str1));
            Assert.AreEqual(false, Shell.isNumeric(str2));
            Assert.AreEqual(false, Shell.isNumeric(str3));
            Assert.AreEqual(false, Shell.isNumeric(str4));
            Assert.AreEqual(false, Shell.isNumeric(str5));
            Assert.AreEqual(false, Shell.isNumeric(str6));

            Assert.AreEqual(false, Shell.isNumeric(arr));
            Assert.AreEqual(false, Shell.isNumeric(arr, 1));
            Assert.AreEqual(true, Shell.isNumeric(arr, 2));
        }

    }
}
