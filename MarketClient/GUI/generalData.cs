using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.GUI
{
    public class generalData
    {
        public IMarketResponse getComList()
        {
            String s = "0,1,2,3,4,5,6,7,8,9";
            String r = "comList";
            IMarketRes ans = new IMarketRes(s,r);
            return ans;
        }
        public class IMarketRes : IMarketResponse
        {
            String type;
            String sstring;
            public String getType()
            {
                return type;
            }

            public IMarketRes(String sstring, String type)
            {
                this.sstring = sstring;
                this.type = type;
            }
        }
    }
}
