using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL
{
    public class GenericMarketResponse : IMarketResponse
    {
        public string response;
        public ResponseType rType;

        public GenericMarketResponse()
        {
            response = "";
            rType = ResponseType.generic;
        }

        public ResponseType getType()
        {
            return rType;
        }

        public override string ToString()
        {
            return response;
        }

    }

    public class MBuySell : GenericMarketResponse
    {
        public string id;


        public MBuySell()
        {
            rType = ResponseType.buysell;
        }

        public override string ToString()
        {
            return id;
        }

    }

    public class Mcancel : GenericMarketResponse
    {
        public Mcancel()
        {
            rType = ResponseType.cancel;
        }


    }

    public class MQReq : GenericMarketResponse
    {
        public int price;
        public int amount;
        public string type;
        public string user;
        public int commodity;

        public MQReq()
        {
            rType = ResponseType.qreq;
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

    public class MQUser : GenericMarketResponse
    {
        public Dictionary<String, int> commodities;
        public double funds;
        public List<int> requests;

        public MQUser()
        {
            rType = ResponseType.quser;
        }


        public override string ToString()
        {
            string output = "Unassigned";

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

    public class MQCommodity : GenericMarketResponse
    {
        public string ask;
        public string bid;

        public MQCommodity()
        {
            rType = ResponseType.qcommodity;
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

        public int getAsk()
        {
            return Int32.Parse(this.ask);
        }

        public int getBid()
        {
            return Int32.Parse(this.bid);
        }

    }
}
