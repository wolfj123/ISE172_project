using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.GUI
{
    public class userWarner
    {
        public bool notTrue (bool [] o)
        {
            bool output = true;
            for(int i = 0; i<o.Length & output; i++)
            {
                if (o[i] == false)
                    output = false;
            }
            return output;
        }
    }
}
