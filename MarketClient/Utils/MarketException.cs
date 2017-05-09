using System;
using MarketClient.PL_BL;

namespace MarketClient.Utils
{
    public class MarketException : Exception, IMarketResponse
    {
        public MarketException()
        {
        }

        public MarketException(string message) : base(message)
        {
        }

        //Added to implmement IMarketResponse
        public override string ToString()
        {
            return this.Message;
        }

        public ResponseType getType()
        {
            return ResponseType.excp;
        }


    }

}