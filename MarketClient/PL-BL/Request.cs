using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class Request
    {
        public String type;
    }

    public class BuySellRequest : Request
    {
       
        public int commodity;
        public int amount;
        public int price;



        //Is this obsolete!?!
        public BuySellRequest (int commodity, int amount, int price) 
        {
            this.amount = amount;
            this.commodity = commodity;
            this.price = price;
        }
    }

    public class BuyRequest : Request
    {

        public int commodity;
        public int amount;
        public int price;

        public BuyRequest(int commodity, int amount, int price)
        {
            this.amount = amount;
            this.commodity = commodity;
            this.price = price;
            this.type = "buy";

        }
    }

    public class SellRequest : Request
    {

        public int commodity;
        public int amount;
        public int price;

        public SellRequest(int commodity, int amount, int price)
        {
            this.amount = amount;
            this.commodity = commodity;
            this.price = price;
            this.type = "sell";

        }
    }

    public class CancelRequest : Request
    {
        public int id;

        public CancelRequest(int id) 
        {
            this.id = id;
            this.type = "cancelBuySell";
        }
    }

    public class QueryBuySellRequest : Request
    {
        public int id;
        
        public QueryBuySellRequest (int id) 
        {
            this.id = id;
            this.type = "queryBuySell";
        }
    }

    public class QueryMarketRequest : Request
    {
        public int commodity;

        public QueryMarketRequest(int commodity) 
        {
            this.commodity = commodity;
            this.type = "queryMarket";
        }
    }

    public class QueryUserRequest : Request 
    {
        public QueryUserRequest () 
        {
            this.type = "queryUser";
        }
    }




}


