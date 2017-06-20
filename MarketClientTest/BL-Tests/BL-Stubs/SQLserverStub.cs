using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClientTest.BL_Tests
{
    public class SQLserverMomentumStub : HistoryDalImplementation
    {
        bool increase;

        public SQLserverMomentumStub(bool increase) : base()
        {
            this.increase = increase;
        }

        public override float PriceAverage(DateTime start, DateTime end, int commodity)
        {
            if (increase)
                return PriceAverageIncrease(start, end, commodity);
            else
                return PriceAverageDecrease(start, end, commodity);
        }

        private float PriceAverageIncrease(DateTime start, DateTime end, int commodity)
        {
            TimeSpan difference = (end - start);
            int differenceInt = difference.Hours;
            if (differenceInt == 1)
                return 100;
            else if (differenceInt == 10)
                return 10;
            else if (differenceInt == 20)
                return 1;
            else
                return -1;
        }

        private float PriceAverageDecrease(DateTime start, DateTime end, int commodity)
        {
            TimeSpan difference = (end - start);
            int differenceInt = difference.Hours;
            if (differenceInt == 1)
                return 1;
            else if (differenceInt == 10)
                return 10;
            else if (differenceInt == 20)
                return 100;
            else
                return -1;
        }
    }
}
