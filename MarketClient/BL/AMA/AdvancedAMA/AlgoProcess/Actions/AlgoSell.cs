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
            //Get available amount from process
            IDictionary<string, int> userCommodities = process.agent.userData.getCommodities();
            string commodity = process.commodity.ToString();
            int amount = userCommodities[commodity];

            //Calculate the buy price:
            //currentAsk + priceBuffer
            int priceBuffer = -1;
            int currentBid = 0;

            //Find currentBid by using the data from the AMA
            bool foundPrice = false;
            for (int i = 0; i <= 9 & !foundPrice; i++)
            {
                MQCommodityWrapper current = process.agent.commoditiesInfo[i];
                if (current.id == process.commodity)
                {
                    foundPrice = true;
                    currentBid = current.getBid();
                }
            }

            int price = currentBid + priceBuffer;

            //Send request
            bool success = false;
            IMarketResponse response = process.comm.SendSellRequest(price, process.commodity, amount);
            if (response.getType() == ResponseType.buySell)
            {
                success = true;
                MBuySell resp = (MBuySell)response;
                process.requestID = resp.getID();
            }
            return success;
        }

        public override string ToString()
        {
            return ("Sell all the supplies of the commodity"); 
        }
    }
}
