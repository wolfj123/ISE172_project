using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.PL_BL;

/*For now I will not be using this class
 * instead- I will be using the milestone1 Request class
 */

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
