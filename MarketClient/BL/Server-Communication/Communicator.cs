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
    public class Communicator : ICommunicator
    {

        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        private static ILog myHistory = LogManager.GetLogger("HistoryLog");

        protected SimpleHTTPClient client;
        protected string url;
        protected string user;
        protected string token;

        public Communicator()
        {
            this.url = "http://ise172.ise.bgu.ac.il";
            this.user = "user36";
            string privateKey = @"-----BEGIN RSA PRIVATE KEY-----
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

            this.token = SimpleCtyptoLibrary.CreateToken(user, privateKey);
            this.client = new SimpleHTTPClient();
        }

        public Communicator(string url, string user, string token)
        {
            this.url = url;
            this.user = user;
            this.token = token;
            this.client = new SimpleHTTPClient();
        }


        public IMarketResponse SendBuyRequest(int price, int commodity, int amount)
        {
            BuyRequest buyReq = new BuyRequest(commodity, amount, price); //create and define buy request
            MBuySell marketResponse = new MBuySell();

            try
            {
                marketResponse.id = client.SendPostRequest<BuyRequest>(url, user, token, buyReq);
                myLogger.Info("Sent Buy Request{commodity:" + commodity + ", price:" + price + ", amount:" + amount + ", url:" + url + "}");
            }
            catch (Exception e)
            {
                return catchMethod(e);
            }

            myHistory.Info("Sent Buy Request-\r\ncommodity:" + commodity + ", price:" + price + ", amount:" + amount + "\nResponse: " + marketResponse.ToString());

            return marketResponse;
        }

        public IMarketResponse SendSellRequest(int price, int commodity, int amount)
        {
            SellRequest sellReq = new SellRequest(commodity, amount, price); //create and define sell request
            MBuySell marketResponse = new MBuySell();

            try
            {
                marketResponse.id = client.SendPostRequest<SellRequest>(url, user, token, sellReq);
                myLogger.Info("Sent Sell Request{commodity:" + commodity + ", price:" + price + ", amount:" + amount + ", url:" + url + "}");
            }
            catch (Exception e)
            {
                return catchMethod(e);
            }

            myHistory.Info("Sent Sell Request-\r\ncommodity:" + commodity + ", price:" + price + ", amount:" + amount + "\nResponse: " + marketResponse.ToString());

            return marketResponse;

        }

        public IMarketResponse SendQueryBuySellRequest(int id)
        {

            QueryBuySellRequest queryBS = new QueryBuySellRequest(id); //create buy/sell query request
            MQReq marketResponse = new MQReq();

            try
            {
                marketResponse = client.SendPostRequest<QueryBuySellRequest, MQReq>(url, user, token, queryBS);
                myLogger.Info("Sent Query Buy/Sell Request{id:" + id + ", Response: " + marketResponse.ToString() + "}");
            }
            catch (Exception e)
            {
                return catchMethod(e);
            }

            myHistory.Info("Sent Query Buy/Sell Request-\r\nid:" + id + "\nResponse: " + marketResponse.ToString());

            return marketResponse;

        }

        public IMarketResponse SendQueryUserRequest()
        {

            QueryUserRequest userReq = new QueryUserRequest(); //create query user requset
            MQUser marketResponse = new MQUser();

            try
            {
                marketResponse = client.SendPostRequest<QueryUserRequest, MQUser>(url, user, token, userReq);
                myLogger.Info("Sent Query Buy/Sell Request{user:" + user + ", url:" + url);
            }
            catch (Exception e)
            {
                return catchMethod(e);
            }

            myHistory.Info("Sent Query Buy/Sell Request-\r\nuser:" + user + "\n Response: " + marketResponse.ToString());

            return marketResponse;
        }

        public IMarketResponse SendQueryMarketRequest(int commodity)
        {
            QueryMarketRequest QMReq = new QueryMarketRequest(commodity); //create query market rquest
            MQCommodity marketResponse = new MQCommodity();

            try
            {
                marketResponse = client.SendPostRequest<QueryMarketRequest, MQCommodity>(url, user, token, QMReq);
                myLogger.Info("Sent Query Market Request{commodity:" + commodity + ", url:" + url + "}");
            }
            catch (Exception e)
            {
                return catchMethod(e);
            }

            myHistory.Info("Sent Query Market Request-\r\ncommodity:" + commodity + "\nResponse: " + marketResponse.ToString());

            return marketResponse;
        }

        public IMarketResponse SendCancelBuySellRequest(int id)
        {
            CancelRequest cancelReq = new CancelRequest(id); //create cancel requst
            MCancel marketResponse = new MCancel();

            try
            {
                marketResponse.response = client.SendPostRequest<CancelRequest>(url, user, token, cancelReq);
                myLogger.Info("Sent Cancel Request{id:" + id + ", url:" + url + "}");
            }
            catch (Exception e)
            {
                return catchMethod(e);
            }

            myHistory.Info("Sent Cancel Request-\r\nid:" + id + "\nResponse: " + marketResponse.ToString());

            return marketResponse;
        }

        public List<MQCommodityWrapper> SendQueryAllMarketRequest()
        {
            throw new NotImplementedException();
        }

        public List<MQReqWrapper> SendQueryAllUserRequest()
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
