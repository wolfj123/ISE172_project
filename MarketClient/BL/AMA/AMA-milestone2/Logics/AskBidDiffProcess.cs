using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using log4net;

/*WIP advanced logic*/

namespace MarketClient.BL
{
    public class AskBidDiff : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            bool success = false;

            IMarketResponse response = process.comm.SendQueryMarketRequest(process.commodity);
            if (response.getType() == ResponseType.qCommodity)
            {
                MQCommodity resp = (MQCommodity)response;
                success = resp.getAsk() <= resp.getBid();
                next(process, success);
            }
            return response;
        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.first;
                process.step(0);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(1);
            }
        }
    }


    //public class DiffBuyAction : BuyAction
    //{
    //    public override void next(LogicProcess process, bool success)
    //    {
    //        if (success)
    //        {
    //            process.queue = LogicQueue.last;
    //            process.step(1);
    //        }
    //        else
    //        {
    //            process.queue = LogicQueue.last;
    //            process.step(1);
    //        }
    //    }
    //}


    public class AskBidDiffProcess : LogicProcess
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public AskBidDiffProcess(bool repeat, ICommunicator comm, int commodity,
            int price, int amount, int id) :
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new AskBidDiff());
            //list.Add(new DiffBuyAction());
            list.Add(new BuyAction());
            list.Add(new SellAction());

            myLogger.Info("Created new AskBidDiffProcess: {Commodity: " + commodity + ", Price: " + price + ", Amount: " + amount + ", Repeat: " + repeat + "}");
        }

        //public override string ToString()
        //{
        //    return "Sell " + amount + " of commodity " + commodity + " when the 'Bid' is equal or above " + price;
        //}
    }


}
