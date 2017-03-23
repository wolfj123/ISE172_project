using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;
using MarketClient.Utils;


namespace MarketClient.DAL
{
    class RealMarketUserData : IMarketUserData
    {
        public String commodities;
        public String funds;
        public String[] requests;

        public String ToString()
        {
            String output = "Commodities: " + this.commodities + ", Funds: " + this.funds + ", Requests: {" + Shell.ArrayToString(requests) + "}";
            return output;

        }

    }
}
