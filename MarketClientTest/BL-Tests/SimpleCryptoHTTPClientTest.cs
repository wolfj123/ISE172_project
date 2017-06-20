using Microsoft.VisualStudio.TestTools.UnitTesting;
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
