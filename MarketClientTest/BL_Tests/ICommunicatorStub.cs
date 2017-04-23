using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;
using MarketClient.PL_BL;

namespace MarketClientTest.BL_Tests
{
    public class ICommunicatorStub : ICommunicator
    {
        public IMarketResponse SendBuyRequest(int price, int commodity, int amount)
        {
            throw new NotImplementedException();
        }

        public IMarketResponse SendCancelBuySellRequest(int id)
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
