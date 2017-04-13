using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL
{
    public class MBuySell : IMarketResponse
    {
        public RequestType rType;
        public string id;


        public MBuySell()
        {
            rType = RequestType.buy;
        }

        public override string ToString()
        {
            return id;
        }

    }

    public class Mcancel : IMarketResponse
    {
        public RequestType rType;
        public string response;

        public Mcancel()
        {
            rType = RequestType.cancel;
        }

        public override string ToString()
        {
            return response;
        }

    }

    public class MQReq : IMarketResponse
    {

        public RequestType rType;
        public int price;
        public int amount;
        public string type;
        public string user;
        public int commodity;

        public MQReq()
        {
            rType = RequestType.query;
        }

        public override string ToString()
        {
            string output = "Unassigned";

            try
            {
                output = "User: " + this.user + "\nType: " + this.type + "\nCommodity: " + this.commodity.ToString() + "\nPrice:" + this.price.ToString() + "\nAmount:" + this.amount.ToString();
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }

            return output;
        }


    }

    public class MQUser : IMarketResponse
    {

        public RequestType rType;
        public Dictionary<String, int> commodities;
        public double funds;
        public List<int> requests;

        public MQUser()
        {
            rType = RequestType.user;
        }


        public override string ToString()
        {
            String output = "Unassigned";

            try
            {
                output = "Commodities: " + Shell.DictionaryToString(commodities) + "\nFunds: " + this.funds.ToString() + "\nRequests: {" + Shell.intListToString(requests) + "}";
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }


            return output;
        }

    }

    public class MQCommodity : IMarketResponse
    {

        public RequestType rType;
        public string ask;
        public string bid;

        public MQCommodity()
        {
            rType = RequestType.market;
        }

        public override string ToString()
        {
            string output = "Unassigned";

            try
            {
                output = "Ask: " + this.ask + "\nBid: " + this.bid;
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }

            return output;
        }

    }




    //PROBABALY OBSOLETE

    /*
    public class MResponse : IMarketResponse
    {
        private ResponseType resType;


        //MarketCommodityOffer
        private String ask;
        private String bid;

        //MarketItemQuery
        private int price;
        private int amount;
        private String type;
        private String user;
        private int commodity;

        //MarketUserData
        private Dictionary<String, int> commodities;
        private double funds;
        private List<int> requests;



        public string toString()
        {



        }
    }

    */
}
