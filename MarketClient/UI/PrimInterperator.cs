using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;
using MarketClient.Utils;
using MarketClient.DataEntries;
using MarketClient.DataEntries.DAL;

namespace MarketClient.UI
{
    public class PrimInterperator : Interperator
    {
        private IMarketClient marketClient;

        public PrimInterperator(LoginInfo loginInfo)
        {
            marketClient = new Poster(loginInfo);
        }


        public String Interperate(Object cmd)
        {
            if (!(cmd is String))
                throw new Exception("PrimInterperator only accepts commands as Strings");

            String s = (String)cmd;

            return Interperate(s);

        }

        private String Interperate (String cmd)
        {
            String[] input = cmd.Split();

            String err;

            switch (input[0])
            {
                case "buy":
                     err = "Invalid Paramaters for 'buy' request. Correct format is: buy <int price> <int commodity> <int amount>";
                    if (input.Length != 4)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else
                    {
                        int response = marketClient.SendBuyRequest(Int32.Parse(input[1]), Int32.Parse(input[2]), Int32.Parse(input[3]));
                        return response.ToString();
                    }
                    break;


                case "sell":
                    err = "Invalid Paramaters for 'sell' request. Correct format is: sell <int price> <int commodity> <int amount>";
                    if (input.Length != 4)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else
                    {
                        int response = marketClient.SendSellRequest(Int32.Parse(input[1]), Int32.Parse(input[2]), Int32.Parse(input[3]));
                        return response.ToString();
                    }
                    break;


                case "cancel":
                    err = "Invalid Paramaters for 'cancel' request. Correct format is: cancel <int request id>";
                    if (input.Length != 2)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else
                    {
                        bool response = marketClient.SendCancelBuySellRequest(Int32.Parse(input[1]));
                        return response.ToString();
                    }
                    break;


                case "qreq":
                    err = "Invalid Paramaters for 'qreq' request. Correct format is: qreq <int request id>";
                    if (input.Length != 2)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else
                    {
                        IMarketItemQuery response = marketClient.SendQueryBuySellRequest(Int32.Parse(input[1]));
                        if (response == null)
                            return "False";
                        else
                            return response.ToString();
                    }
                    break;


                case "quser":
                    err = "Invalid Paramaters for 'quser' request. Correct format is: quser";
                    if (input.Length != 1)
                        Console.WriteLine(err);
                    else
                    {
                        IMarketUserData response = marketClient.SendQueryUserRequest();
                        if (response == null)
                            return "False";
                        else
                            return response.ToString();
                    }
                    break;



                case "qmarket":
                    err = "Invalid Paramaters for 'qmarket' request. Correct format is: qmarket <int commodity>";
                    if (input.Length != 2)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else
                    {
                        IMarketCommodityOffer response = marketClient.SendQueryMarketRequest(Int32.Parse(input[1]));
                        if (response == null)
                            return "False";
                        else
                            return response.ToString();
                    }
                    break;

                default:
                    return "Unknown Command";

            }
            Console.WriteLine();
            return " ";


        }
        




    }




}
