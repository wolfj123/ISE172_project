using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    //Returns true if the Ask of a commodity is lower than required
    public class AlgoAskCompare
    {
        public int requiredAsk;

        public AlgoAskCompare(int requiredAsk)
        {
            this.requiredAsk = requiredAsk;
        }

        public bool conditionIsMet(AlgoProcess process)
        {
            //TODO: get specific commodity ask from ama and compare to desiredAsk

            int placeHolderAsk = 0;
            return (requiredAsk < placeHolderAsk);
        }
    }
}
