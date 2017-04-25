using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.PL_BL
{
    interface InterperatorPB
    {
        Request transReq();

        IMarketResponse getRes();
    }
}
