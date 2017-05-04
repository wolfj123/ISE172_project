using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace WpfApplication1.forms
{
    static class formsMethod
    {
        public static int[] listGet(IMarketResponse res)
        {
            String ans = res.ToString();
            ResponseType type = res.getType();
            return createList(ans, type);
        }

        private static int[] createList(String s, ResponseType t)
        {
            ///do the string to array method according to the type
            int[] a = new int[0];
            return a;
        }
    }
}
