﻿using MarketClient.PL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class AlgoBuy : AlgoAction
    {
        int fundsPercentage;

        public AlgoBuy(int fundsPercentage)
        {
            this.fundsPercentage = fundsPercentage;
        }
        public bool runAction(AlgoProcess process)
        {
            //Calculate the buy price:
            //currentAsk + priceBuffer
            int priceBuffer = 1;
            int currentAsk = 0;

            //Find currentAsk by using the data from the AMA
            bool foundPrice = false;
            for (int i = 0; i<=9 & !foundPrice; i++)
            {
                MQCommodityWrapper current = process.agent.commoditiesInfo[i];
                if (current.id == process.commodity)
                {
                    foundPrice = true;
                    currentAsk = current.getAsk();
                }
            }

            //calculate price and amount
            double funds = process.agent.userData.funds;
            int availableFunds = (int)((fundsPercentage / 100) * funds);
            int price = currentAsk + priceBuffer;
            int amount = price / availableFunds;

            //Send request
            bool success = false;
            IMarketResponse response = process.comm.SendBuyRequest(price, process.commodity,amount);
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