using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public interface AlgoAction
    {
        bool runAction(AlgoProcess process);
    }
}
