using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public abstract class AlgoAnalysis : AlgoActionProcess
    {
        public bool runProcess(AlgoProcessList list)
        {
            return analyse(list);
        }
        public abstract bool analyse(AlgoProcessList list);
    }
}
