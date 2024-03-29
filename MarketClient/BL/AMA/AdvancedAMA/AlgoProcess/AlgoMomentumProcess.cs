﻿using System;
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
            addCondition(new HasNoActiveRequest());
            addCondition(new MomentumIncrease(11, 20, 30));

            setAction(new AlgoBuy(3));
        }
    }


    public class AlgoMomentumSellProcess : AlgoProcess
    {
        public AlgoMomentumSellProcess(AdvancedAMA agent, ICommunicator comm, int commodity)
            : base(agent, comm, commodity)
        {
            addCondition(new HasSupply());
            addCondition(new MomentumDecrease(11, 20, 30));

            setAction(new AlgoSell());
        }
    }
}
