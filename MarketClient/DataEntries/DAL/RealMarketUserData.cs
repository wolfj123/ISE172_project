using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;
using MarketClient.Utils;


namespace MarketClient.DataEntries.DAL
{
    class RealMarketUserData : IMarketUserData
    {
        public Dictionary<string, int> commodities;
        public int funds;
        public List<int> requests;

        public String ToString()
        {
            String output = "Commodities:" + Shell.DictionaryToString(commodities) + ", Funds: " + this.funds.ToString() + ", Requests: {" + Shell.intListToString(requests) + "}";
            return output;
        }

    }
}
