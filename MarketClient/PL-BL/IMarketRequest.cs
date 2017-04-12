using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.PL_BL
{
    public interface IMarketRequest
    {
        Rtype getType();

        string getAuth();

        int getID();

        int getCommodity();

        int getPrice();

        int getAmount();

        string getUser();

        string getKey();
    }

}
}
