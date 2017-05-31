using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class DefaultAdvancedAMA : AdvancedAMA
    {
        public DefaultAdvancedAMA() : base(20,10000)
        {
            ICommunicator comm = new Communicator();

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
}
