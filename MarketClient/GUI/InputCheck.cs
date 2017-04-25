using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.GUI
{
    public class InputCheck
    {
        public bool[] intCheck(Object[] o)
        {
            int arrL = o.Length;
            bool[] output = new bool[arrL];
            for (int i = 0; i < arrL; i++) {
                if (o[i] is int)
                    output[i] = true;
                else
                    output[i] = false;
            }
            return output;
        }
    }
}
