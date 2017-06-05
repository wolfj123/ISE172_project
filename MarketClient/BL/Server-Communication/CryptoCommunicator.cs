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

        public List<MQCommodityWrapper> SendQueryAllMarketRequest()
        {
            throw new NotImplementedException();
        }

        public List<MQReqWrapper> SendQueryAllUserRequest()
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

        private MarketException catchMethod(Exception e)
        {
            myLogger.Error("EXCEPTION");
            if (e is MarketException)
            {
                myLogger.Debug("Recieved Market Exception" + e.Message);
                return (MarketException)e;
            }
            myLogger.Fatal("Unknown exception caught in Communicator: " + e.Message);
            return new MarketException("Illegal response from server. Possible faulty connection.\nError message:\n" + e.Message);
        }
    }
}
