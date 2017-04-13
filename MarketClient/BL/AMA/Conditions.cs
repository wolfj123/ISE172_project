using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL.AMA
{
    public class BidCompare : LogicCondition
    {
        int commodity;
        int bid;
        bool biggerThan;

        public BidCompare(int commodity, int bid, bool biggerThan)
        {
            this.commodity = commodity;
            this.bid = bid;
            this.biggerThan = biggerThan;
        }


        public bool isMet()
        {
            


        }


    }
}
