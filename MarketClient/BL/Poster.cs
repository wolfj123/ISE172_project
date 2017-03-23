using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MarketClient.BL
{
    class Poster : IMarketClient
    {
        private Credentials userInfo;
        SimpleHTTPClient client;

        public Poster(Credentials credenatials)
        {
            this.userInfo = credenatials;
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

            String output = client.SendPostRequest(userInfo.url, userInfo.username, userInfo.token);
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


    