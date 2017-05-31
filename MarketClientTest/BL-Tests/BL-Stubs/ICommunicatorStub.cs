using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;

namespace MarketClientTest
{
    public class CommStubStaticReturn : ICommunicator
    {
        public IMarketResponse buy;
        public IMarketResponse sell;
        public IMarketResponse cancel;
        public IMarketResponse qbuysell;
        public IMarketResponse qmarket;
        public IMarketResponse quser;

        public CommStubStaticReturn(IMarketResponse buy, IMarketResponse sell, IMarketResponse cancel, IMarketResponse qbuysell, IMarketResponse qmarket, IMarketResponse quser)
        {
            this.buy = buy;
            this.sell = sell;
            this.cancel = cancel;
            this.qbuysell = qbuysell;
            this.qmarket = qmarket;
            this.quser = quser;
        }

        public IMarketResponse SendBuyRequest(int price, int commodity, int amount)
        {
            return buy;
        }

        public IMarketResponse SendCancelBuySellRequest(int id)
        {
            return cancel;
        }

        public IMarketResponse SendQueryBuySellRequest(int id)
        {
            return qbuysell;
        }

        public IMarketResponse SendQueryMarketRequest(int commodity)
        {
            return qmarket;
        }

        public IMarketResponse SendQueryUserRequest()
        {
            return quser;
        }

        public IMarketResponse SendSellRequest(int price, int commodity, int amount)
        {
            return sell;
        }

        public List<MQCommodityWrapper> SendQueryAllMarketRequest()
        {
            throw new NotImplementedException();
        }

        public List<MQReqWrapper> SendQueryAllUserRequest()
        {
            throw new NotImplementedException();
        }
    }






    public class ICommunicatorStub : ICommunicator
    {

        public IMarketResponse SendBuyRequest(int price, int commodity, int amount)
        {
            Trace.WriteLine(String.Format("Sent Buy Request: price: {0}, commodity: {1}, amount: {2}",price, commodity, amount));
            MBuySell output = new MBuySell();
            output.id = "1337";
            return output;
        }

        public IMarketResponse SendCancelBuySellRequest(int id)
        {
            Trace.WriteLine(String.Format("Sent Cancel Request: id: {0}", id));
            MCancel output = new MCancel();
            output.response = "OK";
            return output;
        }

        public IMarketResponse SendQueryBuySellRequest(int id)
        {
            //example: {"price": 5, "amount": 10, "type": "buy", "user": "user99", "commodity": 1}
            Trace.WriteLine(String.Format("Sent Buy/Sell Query Request: id: {0}", id));
            MQReq output = new MQReq();
            return output;
        }

        public IMarketResponse SendQueryMarketRequest(int commodity)
        {
            //example: {"ask": 9999999, "bid": 0}
            Trace.WriteLine(String.Format("Sent Commodity Query Request: commodity: {0}", commodity));
            MQCommodity output = new MQCommodity();
            output.ask = "10"; output.bid = "1";
            return output;
        }

        public IMarketResponse SendQueryUserRequest()
        {
            //example: {"commodities": {"0": 0, "1": 0, "2": 0, "3": 0}, "funds": 40, "requests": [1, 2]}
            Trace.WriteLine(String.Format("Sent User Query Request"));
            MQUser output = new MQUser();
            output.requests.Add(1337); output.requests.Add(666);
            output.commodities.Add("1", 10);
            return output;
        }

        public IMarketResponse SendSellRequest(int price, int commodity, int amount)
        {
            Trace.WriteLine(String.Format("Sent Sell Request: price: {0}, commodity: {1}, amount: {2}", price, commodity, amount));
            MBuySell output = new MBuySell();
            output.id = "666";
            return output;
        }

        public List<MQCommodityWrapper> SendQueryAllMarketRequest()
        {
            throw new NotImplementedException();
        }

        public List<MQReqWrapper> SendQueryAllUserRequest()
        {
            throw new NotImplementedException();
        }
    }
}
