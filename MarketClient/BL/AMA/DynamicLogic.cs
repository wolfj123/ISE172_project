using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public enum LogicQueue {first, last, none}

    /*DynamicLogic*/
    public class DynamicLogic
    {
        //ICommunicator comm = new Communicator();

        //private LogicQueue queue;
        private innerLogicMethod innerLogic;
        private birthLogicMethod nextLogic;
        private birthLogicMethod prevLogic;

        private int commodity;
        private int price;
        private int amount;
        private int id;

        private LogicQueue queue
        {
            get
            {
                return queue;
            }

            set
            {
                queue = value;
            }
        }

        public DynamicLogic(LogicQueue queue, innerLogicMethod innerLogic, 
            birthLogicMethod nextLogic, birthLogicMethod prevLogic, 
            int commodity, int price, int amount, int id)
        {
            this.queue = queue;
            this.innerLogic = innerLogic;
            this.nextLogic = nextLogic;
            this.prevLogic = prevLogic;
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.id = id;
        }

        public DynamicLogic run()
        {
            bool success = innerLogic.run(commodity, price, amount);
            if (success)
                return nextLogic.run();
            else
                return prevLogic.run();
        }
    }


    /*Interfaces for methods*/
    public interface innerLogicMethod
    {
        bool run(int commodity, int price, int amount);
    }
    public interface birthLogicMethod
    {
        DynamicLogic run();
    }


    /*Classes for methods*/
    public class BidCompare : innerLogicMethod
    {
        private ICommunicator comm = new Communicator();
        public bool run(int commodity, int price, int amount)
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
        public bool run(int commodity, int price, int amount)
        {
            IMarketResponse response = comm.SendQueryMarketRequest(commodity);
            if (response.getType() != ResponseType.qcommodity)
                return false;

            MQCommodity resp = (MQCommodity)response;
            return resp.getAsk() <= price;
        }
    }


    public class 

}
