using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.PL_BL
{
    public interface IMarketResponse
    {
        ResponseType getType();

        string ToString();
    }
}
