using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class MomentumDecrease : AlgoCondition
    {
        int shortTime;
        int longTime;

        public MomentumDecrease(int shortTime, int longTime)
        {
            this.shortTime = shortTime;
            this.longTime = longTime;
        }

        public bool conditionIsMet(AlgoProcess process)
        {
            // TODO: Buy x shares of a stock when its 50-day moving average goes above the 200-day moving average

            throw new NotImplementedException();
        }
    }
}
