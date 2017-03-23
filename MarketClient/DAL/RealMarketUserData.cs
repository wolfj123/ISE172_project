using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;


//Must convert "requests" arry to strings


namespace MarketClient.DAL
{
    class RealMarketUserData : IMarketUserData
    {
        public String commodities;
        public String funds;
        public String[] requests;

        public String ToString()
        {
            String output = "Commodities: " + this.commodities + ", Funds: " + this.funds + ", Requests:";
            return output;

        }

    }
}
