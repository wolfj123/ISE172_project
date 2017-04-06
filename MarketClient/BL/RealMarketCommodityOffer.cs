using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient.BL
{
    class RealMarketCommodityOffer : IMarketCommodityOffer
    {
        public String ask;
        public String bid;

        public String ToString()
        {


            String output = "Unassigned";

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
}
