using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL.AMA.Actions
{
    public class AlgoBuy : AlgoCondition
    {
        int fundsPercentage;

        public AlgoBuy(int fundsPercentage)
        {
            this.fundsPercentage = fundsPercentage;
        }
        public bool conditionIsMet(AlgoProcess process)
        {
            //TODO: finish buy action
            double funds = process.agent.userData.funds;
            int availableFunds = (int)((fundsPercentage / 100) * funds);

            int price = process.


        }
    }
}
