using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

//TODO: make lists be responses

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
            rType = ResponseType.buySell;
        }

        public override string ToString()
        {
            return id;
        }

        public int getID()
        {
            if (Shell.isNumeric(id))
                return Int32.Parse(id);
            else
                return -1;
        }

    }

    public class MCancel : GenericMarketResponse
    {
        public MCancel()
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
            rType = ResponseType.qReq;
        }

        public override string ToString()
        {
            string output = "Unassigned";

            try
            {
                output = "User: " + this.user + ", Type: " + this.type + ", Commodity: " + this.commodity.ToString() + ", Price:" + this.price.ToString() + ", Amount:" + this.amount.ToString();
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
            rType = ResponseType.qUser;
        }


        public override string ToString()
        {
            string output = "Unassigned";

            try
            {
                output = "Commodities: " + Shell.DictionaryToString(commodities) + " \nFunds: " + this.funds.ToString() + " \nRequests: {" + Shell.intListToString(requests) + "}";
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }
            return output;
        }

        public double Funds()
        {
            return funds;
        }

        public Dictionary<String, int> getCommodities()
        {
            return commodities;
        }

        public List<int> getRequests()
        {
            return requests;
        }

    }

    public class MQCommodity : GenericMarketResponse
    {
        public string ask;
        public string bid;

        public MQCommodity()
        {
            rType = ResponseType.qCommodity;
        }

        public override string ToString()
        {
            string output = "Unassigned";

            try
            {
                output = "Ask: " + this.ask + ", Bid: " + this.bid;
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }

            return output;
        }

        public virtual int getAsk()
        {
            return Int32.Parse(this.ask);
        }

        public virtual int getBid()
        {
            return Int32.Parse(this.bid);
        }

    }


    public class MQCommodityWrapper : MQCommodity
    {
        public MQCommodity info;
        public int id;

        public MQCommodityWrapper()
        {
            rType = ResponseType.qAllCommodity;
        }

        public override int getAsk()
        {
            return info.getAsk();
        }

        public override int getBid()
        {
            return info.getBid();
        }

        public override string ToString()
        {
            return "ID: " +id.ToString() + ", " +  info.ToString();
        }
    }

    
    public class MQReqWrapper : MQReq
    {
        public MQReq request;
        public int id;

        public MQReqWrapper()
        {
            rType = ResponseType.qAllUserReq;
        }

        public override string ToString()
        {
            return "ID " + id.ToString() + ", " + request.ToString();
        }
    }

}
