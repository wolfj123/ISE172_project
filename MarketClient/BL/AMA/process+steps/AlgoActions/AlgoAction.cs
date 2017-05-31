using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public abstract class AlgoAction : AlgoStep
    {
        public bool runStep(AlgoProcess list)
        {
            return runAction(list);
        }
        public abstract bool runAction(AlgoProcess list);
    }
}
