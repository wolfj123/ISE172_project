using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;
using MarketClient.DataEntries;
using MarketClient.PL_BL;



namespace MarketClient.BL
{
    public class Poster : IMarketClient
    {
        private LoginInfo loginInfo;
        private SimpleHTTPClient client;

        public Poster(LoginInfo loginInfo)
        {
            this.loginInfo = loginInfo;
            this.client = new SimpleHTTPClient();
        }

        public int SendBuyRequest(int price, int commodity, int amount)
        {
            BuyRequest buyReq = new BuyRequest(commodity, amount, price); //create and define buy request
            String output = client.SendPostRequest<BuyRequest>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), buyReq);
            if (Utils.Shell.isNumeric(output)) //if the request output is numeric then it succeeded 
                return Int32.Parse(output);
            else // the request failed , printing the output 
            {
                Console.WriteLine(output);
                return -1;
            }
                
        }

        public int SendSellRequest(int price, int commodity, int amount)
        {
            SellRequest sendReq = new SellRequest(commodity, amount, price); //create and define sell request
            String output = client.SendPostRequest<SellRequest>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), sendReq);
            if (Utils.Shell.isNumeric(output)) //if the request output is numeric then it succeeded 
                return Int32.Parse(output);
            else // the request failed , printing the output
            {
                Console.WriteLine(output);
                return -1;
            }
        }


        public IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            QueryBuySellRequest queryBS = new QueryBuySellRequest(id); //create buy/sell query request
            IMarketItemQuery output = client.SendPostRequest<QueryBuySellRequest, RealMarketItemQuery>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), queryBS);
            return output;
        }

        public IMarketUserData SendQueryUserRequest()
        {
            QueryUserRequest userReq = new QueryUserRequest(); //create query user requset
            IMarketUserData output = client.SendPostRequest<QueryUserRequest, RealMarketUserData>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), userReq);
            return output;
        }

        public IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            QueryMarketRequest QMReq = new QueryMarketRequest(commodity); //create query market rquest
            IMarketCommodityOffer output = client.SendPostRequest<QueryMarketRequest, RealMarketCommodityOffer>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), QMReq);
            return output;
        }

        public bool SendCancelBuySellRequest(int id)
        {
            CancelRequest cancelReq = new CancelRequest(id); //create cancel requst
            String output = client.SendPostRequest<CancelRequest>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), cancelReq);
            Console.WriteLine(output); 
            if (output.Equals("OK")) //if the output is OK then it succeeded
                return true;
            else
            {
                return false;
            }

        }

    }
}


    