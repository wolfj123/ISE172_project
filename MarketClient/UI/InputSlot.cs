using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.UI
{
    public class InputSlot
    {
        public String[] names;
        public int[] data;

         
        public InputSlot(String[] names)
        {
            this.names = names;
            this.data = new int[names.Length];
        }
    }
}
