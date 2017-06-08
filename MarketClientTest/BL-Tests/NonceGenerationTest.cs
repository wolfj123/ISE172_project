using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MarketClient.Utils;
using System.Collections.Generic;
using MarketClient.BL;

namespace MarketClientTest.BL_Tests
{
    [TestClass]
    public class NonceGenerationTest
    {
        //TODO: CryptoTest
        [TestMethod]
        public void NonceGenerationTestMethod()
        {
            CryptoCommunicator comm = new CryptoCommunicator();
            SimpleCryptoHTTPClient client = SimpleCryptoHTTPClient.getSimpleCryptoHTTPClient();

            string nonce1 = client.getNonce(); Trace.Write(nonce1+"\n");
            comm.SendQueryUserRequest(); string nonce2 = client.getNonce(); Trace.Write(nonce2+"\n");
            comm.SendQueryUserRequest(); string nonce3 = client.getNonce(); Trace.Write(nonce3+"\n");
            comm.SendQueryUserRequest(); string nonce4 = client.getNonce(); Trace.Write(nonce4+"\n");
            comm.SendQueryUserRequest(); string nonce5 = client.getNonce(); Trace.Write(nonce5+"\n");

            Assert.AreNotEqual(nonce1, nonce2);
            Assert.AreNotEqual(nonce2, nonce3);
            Assert.AreNotEqual(nonce3, nonce4);
            Assert.AreNotEqual(nonce4, nonce5);
        }
    }
}
