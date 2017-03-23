using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{

    public class Request
    {
        public Object auth;
        public String type;
    }


    public class BuySellRequest : Request
    {

        public int commodity;
        public int amount;
        public int price;
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


