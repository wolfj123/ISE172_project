using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public interface Request
    {

        IMarketResponse sendRequest();

        String toString();
    }


    public class BuyRequest : Request
    {
        private int commodity;
        private int amount;
        private int price;





    }


}
