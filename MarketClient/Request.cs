using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{

    public class Request
    {
        public Object auth;
        public String type;

        /*
        public Request(Object auth, String type)
        {
            this.auth = auth;
            this.type = type;
        }
        */
    }


    public class BuySellRequest : Request
    {
        public int commodity;
        public int amount;
        public int price;

        /*
        public BuySellRequest(Object auth, String type, int commodity, int amount, int price)
        {
            this.commodity = commodity;
            this.amount = amount;
            this.price = price;
        }
        */
    }

    public class CancelRequest : Request
    {
        public int id;
    }

    public class QueryBuySellRequest : Request
    {
        public int id;
    }

    public class QueryMarketRequest : Request
    {
        public int commodity;
    }

    public class QueryUserRequest : Request
    {
    }

}

