using MarketClient.PL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class AlgoSell : AlgoAction
    {
        public bool runAction(AlgoProcess process)
        {
            //TODO: get current ask of commodity and add -1
            int price = -1;

            //Get data from process
            IDictionary<string, int> userCommodities = process.agent.userData.getCommodities();
            string commodity = process.commodity.ToString();

            int commoditySupply = userCommodities[commodity];

            bool success = false;
            IMarketResponse response = process.comm.SendSellRequest(price, process.commodity, commoditySupply);
            if (response.getType() == ResponseType.buySell)
            {
                success = true;
                MBuySell resp = (MBuySell)response;
                process.reqeustID = resp.getID();
            }
            return success;
        }
    }
}
