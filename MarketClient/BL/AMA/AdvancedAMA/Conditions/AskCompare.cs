using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    //Returns true if the Ask of a commodity is lower than required
    public class AlgoAskCompare : AlgoCondition
    {
        public int requiredAsk;

        public AlgoAskCompare(int requiredAsk)
        {
            this.requiredAsk = requiredAsk;
        }

        public bool conditionIsMet(AlgoProcess process)
        {
            if (process.agent.commoditiesInfo == null) return false;
         
            int currentAsk = 999999;

            //Find currentAsk by using the data from the AMA
            bool foundPrice = false;

            for (int i = 0; i < process.agent.commoditiesInfo.Count & !foundPrice; i++)
            {
                MQCommodityWrapper current = process.agent.commoditiesInfo[i];
                if (current.id == process.commodity)
                {
                    foundPrice = true;
                    currentAsk = current.getAsk();
                }
            }
            return (requiredAsk <= currentAsk);
        }

        public override string ToString()
        {
            return ("verify if ask is equal or below " + requiredAsk.ToString());
        }
    }
}
