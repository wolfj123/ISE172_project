using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;
using MarketClient.PL_BL;
using log4net;

namespace MarketClient.BL
{
    public interface ICommunicator
    {
        IMarketResponse SendBuyRequest(int price, int commodity, int amount);

        IMarketResponse SendSellRequest(int price, int commodity, int amount);

        IMarketResponse SendQueryBuySellRequest(int id);

        IMarketResponse SendQueryUserRequest();

        IMarketResponse SendQueryMarketRequest(int commodity);

        IMarketResponse SendCancelBuySellRequest(int id);

        List<MQCommodityWrapper> SendQueryAllMarketRequest();

        List<MQReqWrapper> SendQueryAllUserRequest();
    }
}
