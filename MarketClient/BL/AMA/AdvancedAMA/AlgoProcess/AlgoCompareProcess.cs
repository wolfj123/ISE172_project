using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class AlgoCompareBuyProcess : AlgoProcess
    {
        public AlgoCompareBuyProcess(AdvancedAMA agent, ICommunicator comm, int commodity, int maxAsk)
            : base(agent, comm, commodity)
        {
            addCondition(new HasNoActiveRequest());
            addCondition(new AlgoAskCompare(maxAsk));

            setAction(new AlgoBuy(10));
        }
    }


    public class AlgoCompareSellProcess : AlgoProcess
    {
        public AlgoCompareSellProcess(AdvancedAMA agent, ICommunicator comm, int commodity, int minBid)
            : base(agent, comm, commodity)
        {
            addCondition(new HasSupply());
            addCondition(new AlgoBidCompare(minBid));

            setAction(new AlgoSell());
        }
    }
}
