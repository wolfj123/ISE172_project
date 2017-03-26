using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries.DAL
{

    public class Request
    {
       /** protected object auth;
        //public String type;

        
        public Request (object auth)
        {
            this.auth = auth;
        }**/
    }

    public class BuySellRequest : Request
    {
       
        public int commodity;
        public int amount;
        public int price;

        public BuySellRequest (int commodity, int amount, int price) 
        {
            this.amount = amount;
            this.commodity = commodity;
            this.price = price;
        }
    }

    public class CancelRequest : Request
    {
        public int id;

        public CancelRequest(int id) 
        {
            this.id = id;
        }
    }

    public class QueryBuySellRequest : Request
    {
        public int id;
        
        public QueryBuySellRequest (int id) 
        {
            this.id = id;
        }
    }

    public class QueryMarketRequest : Request
    {
        public int commodity;

        public QueryMarketRequest(int commodity) 
        {
            this.commodity = commodity;
        }
    }

    public class QueryUserRequest : Request 
    {
        public QueryUserRequest () 
        {
        }
    }

}


