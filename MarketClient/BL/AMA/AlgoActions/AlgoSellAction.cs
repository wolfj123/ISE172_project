using MarketClient.PL_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketClient.BL
{
    public class AlgoSellAction : AlgoAction
    {
        public override bool runAction(AlgoProcessList list)
        {

            if (list.buyRequestID == -1)
            {

            }

            IMarketResponse response = list.comm.SendSellRequest(list.sellPrice,
                list.commodity, list.amount);

            //Currently not in use, but might be useful
            if (response.getType() == ResponseType.buySell)
            {
                MBuySell resp = (MBuySell)response;
                list.sellRequestID = resp.getID();
            }



        }
    }
}
