using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries.Logger
{
    class Logger
    {
        public Logger() {}

        public static void logging(IMarketRequest request)
        {
            RequestType request = request.getType();
            String stringToWrite;
            switch (request)
            {
                case "buy":
                stringToWrite = getUser() + "send buy request for commodity: "
                    + getCommodity() ", to buy " + getAmount() + " for " + getPrice() + "$";
                    break;
                case "sell":
                stringToWrite = getUser() + " send sell request for commodity: " + getCommodity()
                    + ", to sell " + getAmount() + " for " + getPrice() + "$";
                    break;
                case "cancel":
                    stringToWrite = getUser() + " cancel request with id number: " + getID();
                    break;
                case "query":
                    stringToWrite = getUser() + " send commodity qury on commodity: " + getCommodity();
                    break;
                case "user":
                    stringToWrite = getUser() + " send user query ";
                    break;
                case "market":
                    stringToWrite = getUser() + " send market query";
                }  
        }
        public static void LogInLog(string user)
        {
            String stringToWrite = user + " log in the market.";
        }

        public static void jeneralLog(string output)
        {

        }

        public static void exception(string output)
        {

        }

        public static void response(string output)
        {

        }

        public static void LogingAndResponse(IMarketRequest request, string output)
        {
            logging(request);
            response(output);
        }

    }
}
