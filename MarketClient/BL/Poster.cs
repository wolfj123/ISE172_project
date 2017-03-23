using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DAL;



namespace MarketClient.BL
{
    class Poster : IMarketClient
    {
        private LoginInfo loginInfo;
        SimpleHTTPClient client;

        public Poster(LoginInfo loginInfo)
        {
            this.loginInfo = loginInfo;
            this.client = new SimpleHTTPClient();
        }

        public int SendBuyRequest(int price, int commodity, int amount)
        {
            /*
            BuySellRequest req = new BuySellRequest();
            req.type = "buy";
            //req.auth = ??????
            req.price = price;
            req.commodity = commodity;
            req.amount = amount;

            */

            String output = client.SendPostRequest(loginInfo.url, loginInfo.username, loginInfo.token);
            return Int32.Parse(output);
        }

        int SendSellRequest(int price, int commodity, int amount)
        {
            
        }


        IMarketItemQuery SendQueryBuySellRequest(int id)
        {

        }

        IMarketUserData SendQueryUserRequest()
        {

        }

        IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {

        }

        bool SendCancelBuySellRequest(int id)
        {

        }

    }
}


    