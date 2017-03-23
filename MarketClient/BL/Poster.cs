using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DAL;
using MarketClient.Utils;
using MarketClient.DataEntries;



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
            String output = client.SendPostRequest<BuySellRequest>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), buyReq);
            if (Utils.Shell.isNumeric(output))
                return Int32.Parse(output);
            else
                return -1;
        }

        int SendSellRequest(int price, int commodity, int amount)
        {
            BuySellRequest sendReq = new BuySellRequest(commodity, amount, price);
            String output = client.SendPostRequest<BuySellRequest>(loginInfo.GetURL(), loginInfo.GetUser(), loginInfo.GetToken(), sendReq);
            if (Utils.Shell.isNumeric(output))
                return Int32.Parse(output);
            else
                return -1;
        }


        IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            QueryBuySellRequest queryBS = new QueryBuySellRequest(id);
            RealMarketItemQuery output = client.SendPostRequest<QueryBuySellRequest, RealMarketItemQuery>(loginInfo.GetURL(), loginInfo.GetURL(), loginInfo.GetToken(), queryBS);
            return output;
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


    