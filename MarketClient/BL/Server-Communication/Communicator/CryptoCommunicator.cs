using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;
using MarketClient.PL_BL;
using log4net;

namespace MarketClient.BL
{
    public class CryptoCommunicator : Communicator
    {
        public CryptoCommunicator() : base()
        {
            this.client = SimpleCryptoHTTPClient.getSimpleCryptoHTTPClient();
        }

        public CryptoCommunicator(string url, string user, string privateKey)
            : base(url,user,privateKey)
        {
            this.client = SimpleCryptoHTTPClient.getSimpleCryptoHTTPClient();
        }
    }
}
