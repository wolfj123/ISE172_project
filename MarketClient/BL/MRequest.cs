using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public interface MRequest
    {

        IMarketResponse sendRequest();

        //String toString();
    }


    public class MBuyRequest : MRequest
    {
        private int commodity;
        private int amount;
        private int price;





    }


}
