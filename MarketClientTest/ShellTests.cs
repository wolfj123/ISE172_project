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

            Console.WriteLine(Shell.DictionaryToString(myDict));

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


            Console.WriteLine(Shell.StringListToString(myList));

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

            Console.WriteLine(Shell.isNumeric(str1));
            Console.WriteLine(Shell.isNumeric(str2));
            Console.WriteLine(Shell.isNumeric(str3));
            Console.WriteLine(Shell.isNumeric(str4));
            Console.WriteLine(Shell.isNumeric(str5));
            Console.WriteLine(Shell.isNumeric(str6));


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(Shell.isNumeric(arr));
            Console.WriteLine(Shell.isNumeric(arr,1));
            Console.WriteLine(Shell.isNumeric(arr, 2));
        }

    }
}
