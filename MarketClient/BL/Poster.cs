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
        private SimpleHTTPClient client;

        public Poster(LoginInfo loginInfo)
        {
            this.loginInfo = loginInfo;
            this.client = new SimpleHTTPClient();
        }

        public int SendBuyRequest(int price, int commodity, int amount)
        {
            BuySellRequest buyReq = new BuySellRequest(commodity, amount, price);
            String output = client.SendPostRequest<BuySellRequest>(loginInfo.GetURL, loginInfo.GetUser, loginInfo.GetToken, buyReq);
            return Int32.Parse(output);
        }

        int SendSellRequest(int price, int commodity, int amount)
        {
            BuySellRequest sendReq = new BuySellRequest(commodity, amount, price);
            String output = client.SendPostRequest<BuySellRequest>(loginInfo.GetURL, loginInfo.GetUser, loginInfo.GetToken, buyReq);
            return Int32.Parse(output);
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


    