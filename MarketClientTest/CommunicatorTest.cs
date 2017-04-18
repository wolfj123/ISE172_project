using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;
using MarketClient.Utils;
using MarketClient.PL_BL;

namespace MarketClientTest
{
    [TestClass]
    public class CommunicatorTest
    {
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user36";
        private const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQCuGdcd1NEIrVWC/bjTAWQUfjhC6yJMQF/udGKvO7Yp+Dlnxbhk
1gNQrmD9ICjyEOGrKaubCJnrI0Zcjvfml3n9FhJUJeD6XrE6dSY0znUoNc8juBae
e1dy/29plyXuQOft1fL0MsckfcSWZzJ/64Cpdh515oGeUqQjiZdI6Y/vmQIDAQAB
AoGARiHipgG0suogKERMz7MfvaGayFov1seX3VbE6hIDr6Rue38KaJRNgZK9PzpV
RC3Iukpu9mTgm/f5wA9XjWw3lzGOt0qt08dK/63ESA6e1Bbe2+S3zIqn1JM8SJ6J
ZGys1YCvezEadh00Ia16dZhixVrvtaHERsUHi5dzGP0EYoECQQDHWaJRYEo10lbz
57ajQvTp/oDHGJNjd5l9L1EAQO4+VHc1fIpgYye9g/msPIX6bqpWaTSAMoR7phl5
TuVy9LxPAkEA35NfWoEDbSYw1yjezMwVm2EORYOd18EjGTRYQHSkQbXiyp2NMNKy
DHzSZao7iw38CwYVejo6VNYoyxkQJVUTlwJABjYawqJXbZniL7NWk3uwmeHeLVXs
sbq2Q5pH0dQ0GCkVlcsNnLc6M8N68gzot8be89ZPVnc8fYXNYWQ97fkGLQJAPUT9
1KeWcMsOh2hD5ovnP/WRG6u+Dep32+hkZwWQHhHiXPRgRQj4kkOCxSmpt6nVcI/y
QtTCN42ZEE+GBTUTcQJBAMafJ6ike5spiGCkx2ZzHh9IUu9H9TJ4u5KNxJiP1BIS
rxv9gh/KJgqOXc/YV3RG1FuQdflRy3ZvQutoIrznyKA=
-----END RSA PRIVATE KEY-----";

        [TestMethod]
        public void TestCommUserQuery() {

            string Token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);

            Communicator comm = new Communicator(Url, User, Token);
            IMarketResponse resp = comm.SendQueryUserRequest();
            Console.WriteLine(resp.ToString());
        }

        [TestMethod]
        public void TestCommBuyRequest()
        {
            string Token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);

            Communicator comm = new Communicator(Url, User, Token);
            IMarketResponse resp = comm.SendBuyRequest(1,1,1);
            string respString = resp.ToString();
            Console.WriteLine(respString);

            if (Shell.isNumeric(respString))
                TestCommCancelRequest(Int32.Parse(respString));

        }

        public void TestCommCancelRequest(int id)
        {
            string Token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);

            Communicator comm = new Communicator(Url, User, Token);
            IMarketResponse resp = comm.SendCancelBuySellRequest(id);
            Console.WriteLine(resp.ToString());
        }

    }
}
