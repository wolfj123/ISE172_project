using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.PL_BL
{
    public class Request
    {
        public RequestType type;
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
            this.type = RequestType.buy;

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
                this.type = RequestType.sell;

            }
        }

        public class CancelRequest : Request
        {
            public int id;

            public CancelRequest(int id)
            {
                this.id = id;
                this.type = RequestType.cancel;
            }
        }

        public class QueryBuySellRequest : Request
        {
            public int id;

            public QueryBuySellRequest(int id)
            {
                this.id = id;
                this.type = RequestType.buySellQ;
            }
        }

        public class QueryMarketRequest : Request
        {
            public int commodity;

            public QueryMarketRequest(int commodity)
            {
                this.commodity = commodity;
                this.type = RequestType.marketQ;
            }
        }

        public class QueryUserRequest : Request
        {
            public QueryUserRequest()
            {
                this.type = RequestType.userQ;
            }
        }
    }



