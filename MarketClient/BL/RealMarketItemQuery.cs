using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient.BL
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
            String output = "Unassigned";

            try
            {
                output = "User: " + this.user + "\nType: " + this.type + "\nCommodity: " + this.commodity.ToString() + "\nPrice:" + this.price.ToString() + "\nAmount:" + this.amount.ToString();
            }
            catch (Exception e)
            {
                output = "\n\n" + e.Message;
            }

            return output;
        }
        

    }
}
