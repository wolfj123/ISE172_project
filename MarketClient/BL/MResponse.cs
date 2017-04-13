using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL
{
    public class MResponse : IMarketResponse
    {
        private ResponseType resType;


        //MarketCommodityOffer
        private String ask;
        private String bid;

        //MarketItemQuery
        private int price;
        private int amount;
        private String type;
        private String user;
        private int commodity;

        //MarketUserData
        private Dictionary<String, int> commodities;
        private double funds;
        private List<int> requests;



        public string toString()
        {



        }




    }
}
