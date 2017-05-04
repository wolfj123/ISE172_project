using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL.AMA
{

//*Low-Level logic block - simple sending of requests
    public abstract class MarketAction : LogicBlock
    {
        private bool loop;

        public bool repeat()
        {
            return loop;
        }

        public void setRepeat(bool loop)
        {
            this.loop = loop;
        }

        public object runBlock()
        {
            IMarketResponse resp = (IMarketResponse)ask();

            if (isMet(resp))
                return action(resp);
            else
                return resp;
        }

        public abstract bool isMet(object obj);

        public abstract object ask();

        public abstract object action(object obj);
    }


    public class BidBuy : MarketAction
    {
        private int commodity;
        private int bid;
        private int amount;

        private ICommunicator communicator;

        public BidBuy(int commodity, int bid , int amount, ICommunicator communicator)
        {
            this.bid = bid;
            this.commodity = commodity;
            this.communicator = communicator;
            this.amount = amount;

            setRepeat(false);
        }

        public override bool isMet(object obj)
        {
            if (obj == null)
                throw new NullReferenceException("response cannot be null");

            if (obj is MarketException)
                return false;

            if (!(obj is MQCommodity))
                throw new ArgumentException("response must be MQCommodity");

            MQCommodity currResponse = (MQCommodity)obj;

            if (Int32.Parse(currResponse.bid) <= this.bid)
                return true;
            else return false;
        }

        public override object ask()
        {
            return communicator.SendQueryMarketRequest(commodity);
        }

        public override object action(object obj)
        {
            if (obj == null || !(obj is MQCommodity))
                throw new NullReferenceException("response must be valid MQCommodity");

            MQCommodity resp = (MQCommodity)obj;
            int price = resp.getBid()+1;

            return communicator.SendBuyRequest(price, commodity, amount);

        }
    }

    public class CollectInfo : MarketAction
    {
        private int commodity;
        private ICommunicator communicator;

        public CollectInfo(int commodity, ICommunicator communicator)
        {
            this.commodity = commodity;
            this.communicator = communicator;
        }

        public override bool isMet(object obj)
        {
            return true;
        }

        public override object ask()
        {
            return null;
        }

        public override object action(object obj)
        {
            return communicator.SendQueryMarketRequest(commodity);
        }

    }




}
