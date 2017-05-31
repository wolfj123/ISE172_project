using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class AlgoMomentumBuyProcess : AlgoProcess
    {
        public AlgoMomentumBuyProcess(AdvancedAMA agent, ICommunicator comm, int commodity) 
            : base(agent,comm,commodity)
        {
            //TODO: momentum increase integers making any sense
            this.conditions.Add(new HasNoActiveRequest());
            this.conditions.Add(new MomentumIncrease(5,20));

            this.action = new AlgoBuy(15);
        }
    }


    public class AlgoMomentumSellProcess : AlgoProcess
    {
        public AlgoMomentumSellProcess(AdvancedAMA agent, ICommunicator comm, int commodity)
            : base(agent, comm, commodity)
        {
            //TODO: momentum increase integers making any sense
            this.conditions.Add(new HasSupply());
            this.conditions.Add(new MomentumDecrease(5, 20));

            this.action = new AlgoSell();
        }
    }
}
