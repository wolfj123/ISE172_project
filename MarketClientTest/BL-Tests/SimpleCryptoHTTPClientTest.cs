using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MarketClient.Utils;
using System.Collections.Generic;
using MarketClient.BL;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class SimpleCryptoHTTPClientTest
    {
        [TestMethod]
        public void SimpleCryptoHTTPClientTestSingletonDesign()
        {
            SimpleCryptoHTTPClient client1 = SimpleCryptoHTTPClient.getSimpleCryptoHTTPClient();

            SimpleCryptoHTTPClient client2 = SimpleCryptoHTTPClient.getSimpleCryptoHTTPClient();

            Assert.AreEqual(client1, client2);
        }
    }
}
