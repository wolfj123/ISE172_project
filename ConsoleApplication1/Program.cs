using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.UI;
using MarketClient.BL;
using MarketClient.PL_BL;

namespace Application
{
    class Program
    {
        
        static void Main()
        {
            Boolean test = true;
            
            if(!test)
            {
                Interperator interp = new PrimInterperator(new DefaultLoginInfo()); 
                Display.Welcome();

                while (true)
                {
                    String cmd = Console.ReadLine();
                    Console.WriteLine(interp.Interperate(cmd));
                }
            }
            else
            {
                /** AMA test **/
                /*
                Console.WriteLine("We are a'go!");
                AMA testAMA = new DefaultAMA();
                testAMA.enable(true);

                System.Threading.Thread.Sleep(10000 * 3);
                testAMA.enable(false);
                */


                /** Comm test**/

                ICommunicator comm = new TestMarketCommunicator();


                String cmd = Console.ReadLine();
            }

        }
        
    }

}
