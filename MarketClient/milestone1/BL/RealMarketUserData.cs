﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;
using MarketClient.Utils;


namespace MarketClient.BL
{
    class RealMarketUserData : IMarketUserData
    {
        public Dictionary<String, int> commodities;
        public double funds;
        public List<int> requests;


        public override string ToString()
        {
            string output = "Unassigned";

            try
            {
                output = "Commodities: " + Shell.DictionaryToString(commodities) + "\nFunds: " + this.funds.ToString() + "\nRequests: {" + Shell.intListToString(requests) + "}";
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }


            return output;
        }

    }
}
