using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL
{

    public interface LogicBlock
    {
        bool isMet(IMarketResponse response);

        bool repeat();

        void setRepeat();

        IMarketResponse ask();

        IMarketResponse action();

        IMarketResponse runBlock();
    }




    public class BidBuy : LogicBlock
    {

        /* TODO: 
         * this object should send a query for a commodity and if the bid is a lower than a threshold send a buy request
         */

        private int commodity;
        private int bid;
        private bool loop;

        public BidBuy(int commodity, int bid)
        {
            this.bid = bid;
            this.commodity = commodity;
            loop = false;
        }

        bool isMet(IMarketResponse response)
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

        public bool repeat()
        {
            return loop;
        }

        public void setRepeat(bool loop)
        {
            this.loop = loop;
        }



    }


}
