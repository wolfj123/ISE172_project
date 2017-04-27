using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public interface innerLogicMethod
    {
        bool run(int commodity, int price, int amount, int id);
    }

    public class BidCompare : innerLogicMethod
    {
        private ICommunicator comm = new Communicator();
        public bool run(int commodity, int price, int amount, int id)
        {
            IMarketResponse response = comm.SendQueryMarketRequest(commodity);
            if (response.getType() != ResponseType.qcommodity)
                return false;

            MQCommodity resp = (MQCommodity)response;
            return resp.getBid() >= price;
        }
    }


    public class AskCompare : innerLogicMethod
    {
        private ICommunicator comm = new Communicator();
        public bool run(int commodity, int price, int amount, int id)
        {
            IMarketResponse response = comm.SendQueryMarketRequest(commodity);
            if (response.getType() != ResponseType.qcommodity)
                return false;

            MQCommodity resp = (MQCommodity)response;
            return resp.getAsk() <= price;
        }
    }


    public class hasExistingRequest : innerLogicMethod
    {
        private ICommunicator comm = new Communicator();
        public bool run(int commodity, int price, int amount, int id)
        {
            IMarketResponse response = comm.SendQueryBuySellRequest(id);
            if (response.getType() != ResponseType.qreq)
                return false;

            return true;
        }
    }

    public class hasCommodity : innerLogicMethod
    {
        private ICommunicator comm = new Communicator();
        public bool run(int commodity, int price, int amount, int id)
        {
            IMarketResponse response = comm.SendQueryUserRequest();
            if (response.getType() != ResponseType.quser)
                return false;

            MQUser resp = (MQUser)response;
            Dictionary<string, int> commodityList =resp.getCommodities();
            int currAmount = commodityList[commodity.ToString()];
            return currAmount > 0;
        }
    }


}
