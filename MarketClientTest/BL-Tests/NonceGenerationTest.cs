using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MarketClient.Utils;
using System.Collections.Generic;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class NonceGenerationTest
    {
        //TODO: CryptoTest
        [TestMethod]
        public void NonceGenerationTestMethod()
        {
            List<String> output = new List<String>();
            for (int i = 0; i<10; i++)
            {
                output.Add(SimpleCtyptoLibrary.createNonce() + "\n");
            }

            foreach(String s in output)
            {
                Trace.Write(s);
            }
        }
    }
}
