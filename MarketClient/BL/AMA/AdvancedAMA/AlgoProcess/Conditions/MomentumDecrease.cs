using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient.BL
{
    public class MomentumDecrease : AlgoCondition
    {
        public int minTime;
        public int medTime;
        public int maxTime;
        public SQL_DAL_implementation sql;

        public MomentumDecrease(int minTime, int medTime, int maxTime)
        {
            this.minTime = minTime;
            this.medTime = medTime;
            this.maxTime = maxTime;
            this.sql = new SQL_DAL_implementation();
        }

        public bool conditionIsMet(AlgoProcess process)
        {
            // TODO: Buy x shares of a stock when its 50-day moving average goes above the 200-day moving average
            DateTime minTimeRange = DateTime.Now.AddMinutes(-minTime);
            float minAverage = sql.PriceAverage(minTimeRange, DateTime.Now, process.commodity);

            DateTime medTimeRange = DateTime.Now.AddMinutes(-medTime);
            float medAverage = sql.PriceAverage(medTimeRange, DateTime.Now, process.commodity);

            DateTime maxTimeRange = DateTime.Now.AddMinutes(-maxTime);
            float maxAverage = sql.PriceAverage(maxTimeRange, DateTime.Now, process.commodity);

            if (minAverage < 0 | medAverage < 0 | maxAverage < 0) return false;

            return (minAverage < medAverage) & (medAverage < maxAverage);
        }

        public override string ToString()
        {
            return ("verify if the " + minTime + "-moving average is above the " + maxTime + "-moving average");
        }
    }
}
