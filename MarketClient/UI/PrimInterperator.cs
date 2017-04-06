using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;
using MarketClient.Utils;
using MarketClient.DataEntries;

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
            String[] input = cmd.Split(); //split the input into words in order to analyze it

            String err;

            switch (input[0]) //gose throw every case senarieo possibale for the input
            {
                case "buy":
                     err = "Invalid Paramaters for 'buy' request. Correct format is: buy <int price> <int commodity> <int amount>";
                    if (input.Length != 4) 
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else //the input is leagle 
                    {
                        int response = -1;

                        try //send buy requst and return the received output
                        {
                            response = marketClient.SendBuyRequest(Int32.Parse(input[1]), Int32.Parse(input[2]), Int32.Parse(input[3]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        return response == -1 ? "" : response.ToString(); //if the send request failed return -1 else return the response
                    }
                    break;


                case "sell":
                    err = "Invalid Paramaters for 'sell' request. Correct format is: sell <int price> <int commodity> <int amount>";
                    if (input.Length != 4)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else //send sell requst and return the received output
                    {
                        int response = -1;

                        try
                        {
                            response = marketClient.SendSellRequest(Int32.Parse(input[1]), Int32.Parse(input[2]), Int32.Parse(input[3]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        return response == -1 ? "" : response.ToString(); //if the buy request failed return -1 else return the response
                    }
                    break;


                case "cancel":
                    err = "Invalid Paramaters for 'cancel' request. Correct format is: cancel <int request id>";
                    if (input.Length != 2)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else //send cancel requst and return the received output
                    {
                        bool response = false;

                        try
                        {
                            response = marketClient.SendCancelBuySellRequest(Int32.Parse(input[1]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        
                        if (response)
                            return "OK";
                        else return "";
                    }
                    break;


                case "qreq":
                    err = "Invalid Paramaters for 'qreq' request. Correct format is: qreq <int request id>";
                    if (input.Length != 2)
                        Console.WriteLine(err);
                    else if (!Shell.isNumeric(input, 1))
                        Console.WriteLine(err);
                    else //send Market Item Query requst and return the received output
                    {

                        IMarketItemQuery response = new RealMarketItemQuery();

                        bool error = false;

                        try
                        {
                            response = marketClient.SendQueryBuySellRequest(Int32.Parse(input[1]));
                        }
                        catch (Exception e)
                        {
                            error = true;
                            Console.WriteLine(e.Message);
                        }
                        
                        if (error)
                            return "";
                        else
                            return response.ToString();
                    }
                    break;


                case "quser":
                    err = "Invalid Paramaters for 'quser' request. Correct format is: quser";
                    if (input.Length != 1)
                        Console.WriteLine(err);
                    else //send market user data requst and return the received output
                    {
                        IMarketUserData response = new RealMarketUserData();
                        bool error = false;

                        try
                        {
                            response = marketClient.SendQueryUserRequest();
                        }
                        catch (Exception e)
                        {
                            error = true;
                            Console.WriteLine(e.Message);
                        }
                       
                        if (error)
                            return "";
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
                    else //send Market commodity offer requst and return the received output
                    {
                        IMarketCommodityOffer response = new RealMarketCommodityOffer();

                        bool error = false;

                        try
                        {
                            response = marketClient.SendQueryMarketRequest(Int32.Parse(input[1]));
                        }
                        catch (Exception e)
                        {
                            error = true;
                            Console.WriteLine(e);
                        }
                        
                        if (error)
                            return "";
                        else
                            return response.ToString();
                    }
                    break;

                default: //in case of invalid input
                    return "Unknown Command";

            }
            Console.WriteLine();
            return " ";


        }
        




    }




}
