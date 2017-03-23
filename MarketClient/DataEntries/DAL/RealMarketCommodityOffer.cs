using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient.DataEntries.DAL
{
    class RealMarketCommodityOffer : IMarketCommodityOffer
    {
        public String ask;
        public String bid;

        public String ToString()
        {
            String output = "Ask: " + this.ask + ", Bid: " + this.bid;
            return output;
        }
    }
}
