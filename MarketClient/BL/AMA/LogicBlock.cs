using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL
{

    public abstract class LogicBlock
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

        public IMarketResponse runBlock()
        {
            IMarketResponse resp = ask();

            if (isMet(resp))
                return action();
            else
                return resp;
        }

        public abstract bool isMet(IMarketResponse response);

        public abstract IMarketResponse ask();

        public abstract IMarketResponse action(IMarketResponse response);
    }


    public class BidBuy : LogicBlock
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

        public override bool isMet(IMarketResponse response)
        {
            if (response == null)
                throw new NullReferenceException("response cannot be null");

            if (response is MarketException)
                return false;

            if (!(response is MQCommodity))
                throw new ArgumentException("response must be MQCommodity");

            MQCommodity currResponse = (MQCommodity)response;

            if (Int32.Parse(currResponse.bid) <= this.bid)
                return true;
            else return false;
        }

        public override IMarketResponse ask()
        {
            return communicator.SendQueryMarketRequest(commodity);
        }

        public override IMarketResponse action(IMarketResponse response)
        {
            if (response == null || !(response is MQCommodity))
                throw new NullReferenceException("response must be valid MQCommodity");

            MQCommodity resp = (MQCommodity)response;
            int price = resp.getBid()+1;

            return communicator.SendBuyRequest(price, commodity, amount);

        }
    }

    public class collectInfo : LogicBlock
    {

    }

}
