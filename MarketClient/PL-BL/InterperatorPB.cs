using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;

namespace MarketClient.PL_BL
{
    static public class InterperatorPB
    {
        static private ICommunicator comm = new Communicator();
        static private AMA ama = new DefaultAMA(comm);
        public static IMarketResponse sendRequest(Request req)
        {
            switch (req.type)
            {
                case "buy":
                    BuyRequest buyReq = (BuyRequest)req;
                    return comm.SendBuyRequest(buyReq.price, buyReq.commodity, buyReq.amount);

                case "sell":
                    SellRequest sellReq = (SellRequest)req;
                    //return comm.SendSellRequest(sellReq.price, sellReq.commodity, sellReq.amount);
                    IMarketResponse resp = comm.SendSellRequest(sellReq.price, sellReq.commodity, sellReq.amount);
                    return resp;
                case "cancelBuySell":
                    CancelRequest cancelReq = (CancelRequest)req;
                    return comm.SendCancelBuySellRequest(cancelReq.id);

                case "queryBuySell":
                    QueryBuySellRequest queryReq = (QueryBuySellRequest)req;
                    return comm.SendQueryBuySellRequest(queryReq.id);

                case "queryMarket":
                    QueryMarketRequest queryMarketReq = (QueryMarketRequest)req;
                    return comm.SendQueryMarketRequest(queryMarketReq.commodity);

                case "queryUser":
                    //return comm.SendQueryUserRequest();
                    IMarketResponse resp1 = comm.SendQueryUserRequest();
                    return resp1;

                default:
                    return null;
            }
        }

        public static List<MQCommodityWrapper> sendAllCommodityRequest()
        {
             return comm.SendQueryAllMarketRequest();
        }

        public static List<MQReqWrapper> sendAllUserRequest()
        {
            return comm.SendQueryAllUserRequest();
        }
    }
}
