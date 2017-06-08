using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    //verifies whetehr the process has an existing request in the market
    public class HasNoActiveRequest : AlgoCondition
    {
        //Returns true if there is no active request false otherwise
        public bool conditionIsMet(AlgoProcess process)
        {
            return process.requestID == -1;
        }
    }
}
