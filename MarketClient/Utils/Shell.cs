using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.Utils
{
    static public class Shell
    {
        static public bool isNumeric(String s)
        {
            int i = 0;
            return int.TryParse(s, out i);
        }

    }
}
