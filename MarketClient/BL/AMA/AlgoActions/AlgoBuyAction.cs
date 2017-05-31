using MarketClient.PL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketClient.BL
{
    public class AlgoBuyAction : AlgoAction
    {
        public override bool runAction(AlgoProcessList list)
        {

            //Attempt to buy the commodity
            bool success = false;
            IMarketResponse response = list.comm.SendBuyRequest(list.buyPrice,
                list.commodity, list.amount);

            //If buy request is succssful - update the buyRequestID of the list
            if (response.getType() == ResponseType.buySell)
            {
                success = true;
                MBuySell resp = (MBuySell)response;
                list.buyRequestID = resp.getID();
            }
            return success;
        }
    }
}
