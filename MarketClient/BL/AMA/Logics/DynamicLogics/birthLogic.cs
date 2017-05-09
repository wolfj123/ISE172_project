using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public interface BirthLogicMethod
    {
        DynamicLogic run(int commodity, int price, int amount, int id);
    }


    public class createBidBuyLogic : BirthLogicMethod
    {
        public DynamicLogic run(int commodity, int price, int amount, int id)
        {
            return 
        }
    }

}
