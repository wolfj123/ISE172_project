using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public abstract class AlgoAnalysis : AlgoStep
    {
        public bool runStep(AlgoProcess list)
        {
            return analyse(list);
        }
        public abstract bool analyse(AlgoProcess list);
    }
}
