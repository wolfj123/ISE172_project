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
        enum mainAction { test, status, normal };

        static void Main()
        {

            mainAction action = mainAction.
                normal;


            if (action == mainAction.normal)
            {
                Interperator interp = new PrimInterperator(new DefaultLoginInfo());
                Display.Welcome();
                while (true)
                {
                    String cmd = Console.ReadLine();
                    Console.WriteLine(interp.Interperate(cmd));
                }
            }
            else if (action == mainAction.test)
            {
                /** AMA test **/

                Console.WriteLine("We are a'go!");
                AMA testAMA = new DefaultAMA();
                testAMA.enable(true);

                System.Threading.Thread.Sleep(10000 * 3);
                testAMA.enable(false);

            }else { 

                /** Comm test**/
                
                ICommunicator comm = new TestMarketCommunicator();

                IMarketResponse resp = comm.SendQueryUserRequest();
                Console.WriteLine(resp.ToString());


                resp = comm.SendQueryMarketRequest(1);
                Console.WriteLine(resp.ToString());



                String cmd = Console.ReadLine();
                
            }

        }
        
    }

}
