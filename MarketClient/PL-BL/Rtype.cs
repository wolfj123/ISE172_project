using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.PL_BL
{
    public enum  RequestType
    {
        buy,
        sell,
        cancel,
        buySellQ,
        userQ,
        marketQ
    }

    public enum ResponseType
    {
        buysell,
        cancel,
        quser,
        qcommodity,
        qreq,
        excp,
        generic
    }

}
