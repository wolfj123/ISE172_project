using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class DefaultMomentumAMA : AdvancedAMA
    {
        public DefaultMomentumAMA() : base(20,10000, new CryptoCommunicator())
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

    //TODO: test this ama
    public class DefaultCompareAMA : AdvancedAMA
    {
        public DefaultCompareAMA() : base(20, 10000, new CryptoCommunicator())
        {
            /*
            for (int commodity = 9; commodity >= 0; commodity--)
            {
                add(new AlgoCompareBuyProcess(this, comm, commodity));
            }

            for (int commodity = 9; commodity >= 0; commodity--)
            {
                add(new AlgoCompareSellProcess(this, comm, commodity));
            }
            */
            add(new AlgoCompareBuyProcess(this, comm, 9));
            add(new AlgoCompareSellProcess(this, comm, 4));

        }
    }
}
