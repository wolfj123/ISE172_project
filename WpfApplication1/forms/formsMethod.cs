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
            String type = res.getType();
            return createList(ans, type);
        }

        private static int[] createList(String s, String type)
        {
            ///do the string to array method according to the type
            switch (type)
            {
                case "comList":
                    {
                        int[] a = new int[10];
                        for(int i =0; i < s.Length; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (s[i] != ',')
                                {
                                    int com = Convert.ToInt32(s[i]);
                                    a[j] = com;
                                }
                            }
                        }
                        return a;
                    }
            }
            return null;
        }


    }
}
