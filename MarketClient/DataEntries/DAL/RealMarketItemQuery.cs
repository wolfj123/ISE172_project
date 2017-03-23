using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient.DataEntries.DAL
{
    class RealMarketItemQuery : IMarketItemQuery
    {
        public int price;
        public int amount;
        public String type;
        public String user;
        public int commodity;

        public String ToString()
        {
            String output = "User: " + this.user + ", Type: " + this.type + ", Commodity: " + this.commodity.ToString() + ", Price:" + this.price.ToString() +", Amount:" +this.amount.ToString();
            return output;
        }

    }
}
