using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.PL_BL
{
    interface IMarketRequest
    {
        Rtype getType();

        String getAuth();

        int getID();

        int getCommodity();

        int getPrice();

        int getAmount();

    }
}
