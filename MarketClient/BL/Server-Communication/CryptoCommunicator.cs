using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{

    //TODO: build CryptoComm
    public class CryptoCommunicator : ICommunicator
    {
        public IMarketResponse SendBuyRequest(int price, int commodity, int amount)
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendCancelBuySellRequest(int id)
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendQueryAllMarketRequest()
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendQueryAllUserRequest()
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendQueryBuySellRequest(int id)
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendQueryMarketRequest(int commodity)
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendQueryUserRequest()
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendSellRequest(int price, int commodity, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
