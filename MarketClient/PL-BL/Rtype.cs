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
        query,
        user,
        market
    }

    public enum ResponseType
    {
        buySell,
        cancel,
        qUser,
        qCommodity,
        qReq,
        excp,
        qAllCommodity,
        qAllUserReq,
        generic
    }

}
