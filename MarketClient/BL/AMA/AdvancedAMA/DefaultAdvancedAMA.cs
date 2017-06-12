using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class DefaultAdvancedAMA : AdvancedAMA
    {
        public DefaultAdvancedAMA() : base(20, 10000, new CryptoCommunicator())
        {
        }
    }

    public class DefaultMomentumAMA : DefaultAdvancedAMA
    {
        public DefaultMomentumAMA() : base()
        {
            for(int commodity=9; commodity>=0; commodity--)
            {
                add(new AlgoMomentumBuyProcess(this, comm, commodity));
            }

            for (int commodity = 9; commodity >= 0; commodity--)
            {
                add(new AlgoMomentumSellProcess(this, comm, commodity));
            }
        }
    }

    public class DefaultCompareAMA : DefaultAdvancedAMA
    {
        public DefaultCompareAMA() : base()
        {
            int maxAsk = 8;
            int minBid = 15;

            for (int commodity = 9; commodity >= 0; commodity--)
            {
                add(new AlgoCompareBuyProcess(this, comm, commodity, maxAsk));
            }

            for (int commodity = 9; commodity >= 0; commodity--)
            {
                add(new AlgoCompareSellProcess(this, comm, commodity, minBid));
            }
        }
    }
}
