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
            if (process.agent.commoditiesInfo == null) return false;

            int currentBid = 0;

            //Find currentBid by using the data from the AMA
            bool foundPrice = false;
            for (int i = 0; i < process.agent.commoditiesInfo.Count & !foundPrice; i++)
            {
                MQCommodityWrapper current = process.agent.commoditiesInfo[i];
                if (current.id == process.commodity)
                {
                    foundPrice = true;
                    currentBid = current.getBid();
                }
            }
            return (requiredBid >= currentBid);
        }

        public override string ToString()
        {
            return ("verify if bid is equal or above " + requiredBid.ToString());
        }
    }

}
