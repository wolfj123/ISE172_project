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
            double funds = process.agent.userData.funds;
            int availableFunds = (int)((fundsPercentage / 100) * funds);

            //TODO: get current bid of commodity and add +1
            int price = -1;

            int amount = price / availableFunds;

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
