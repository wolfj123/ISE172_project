using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class MomentumIncrease : AlgoCondition
    {
        int shortTime;
        int longTime;
 
        public MomentumIncrease(int shortTime, int longTime)
        {
            this.shortTime = shortTime;
            this.longTime = longTime;
        }
        public bool conditionIsMet(AlgoProcess process)
        {
            // TODO: Sell x shares of a stock when its 50-day moving average goes below the 200-day moving average
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ("verify if the " + shortTime + "-moving average is below the " + longTime + "-moving average");
        }
    }
}
