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
            int currentAsk = 999999;

            //Find currentAsk by using the data from the AMA
            bool foundPrice = false;
            for (int i = 0; i <= 9 & !foundPrice; i++)
            {
                MQCommodityWrapper current = process.agent.commoditiesInfo[i];
                if (current.id == process.commodity)
                {
                    foundPrice = true;
                    currentAsk = current.getAsk();
                }
            }
            return (requiredAsk < currentAsk);
        }
    }
}
