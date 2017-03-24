using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;
using MarketClient.DataEntries;
using MarketClient.DataEntries.DAL;


namespace MarketClient.UI
{
    class Program
    {
        static void Main()
        {
            Interperator interp = new PrimInterperator(new DefaultLoginInfo());
            Display.Welcome();

            while (true)
            {
                String cmd = Console.ReadLine();
                Console.WriteLine(interp.Interperate(cmd));
           
            }
            
        }
        
    }
    
}
