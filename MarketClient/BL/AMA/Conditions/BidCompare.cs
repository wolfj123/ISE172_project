using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    //Returns true if the Bid of a commodity is higher than required
    public class AlgoBidCompare : AlgoCondition
    {
        public int requiredBid;

        public AlgoBidCompare(int requiredBid)
        {
            this.requiredBid = requiredBid;
        }

        public bool conditionIsMet(AlgoProcess process)
        {
            //TODO: get specific commodity bid from ama and compare to desiredBid

            int placeHolderBid = 0;
            return (requiredBid > placeHolderBid);
        }
    }
}
