using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using log4net;

namespace MarketClient.BL
{
    public interface InnerLogic
    {
        object run(LogicProcess process);
    }

    public class BidCompare : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            bool success = false;

            IMarketResponse response = process.comm.SendQueryMarketRequest(process.commodity);
           // myLogger.Info("BidCompare: Sent query");

            if (response.getType() == ResponseType.qcommodity)
            {
                MQCommodity resp = (MQCommodity)response;
                success = resp.getBid() >= process.price;
                next(process, success);
            }
            return response;
        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.first;
                process.step(1);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(0);
            } 
        }
    }


    public class AskCompare : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            bool success = false;

            IMarketResponse response = process.comm.SendQueryMarketRequest(process.commodity);
            if (response.getType() == ResponseType.qcommodity)
            {
                MQCommodity resp = (MQCommodity)response;
                success = resp.getAsk() <= process.price;
                next(process, success);
            }
            return response;
        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.first;
                process.step(1);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(0);
            }
        }
    }


    public class hasExistingRequest : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            
            IMarketResponse response = process.comm.SendQueryBuySellRequest(process.id);
            bool success = (response.getType() != ResponseType.qreq);

            if (!success)
                process.id = -1;

            next(process, success);
            return response;

        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.first;
                process.step(1);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(0);
            }
        }

    }

    public class hasCommodity : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            bool success = false;
            IMarketResponse response = process.comm.SendQueryUserRequest();
            if (response.getType() == ResponseType.quser)
            {
                MQUser resp = (MQUser)response;
                Dictionary<string, int> commodityList = resp.getCommodities();
                int currAmount = commodityList[process.commodity.ToString()];
                success = (currAmount > 0);
            }
            next(process, success);
            return response;
        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.first;
                process.step(1);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(0);
            }
        }
    }

    public class BuyAction : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            bool success = false;
            IMarketResponse response = process.comm.SendBuyRequest(process.price,process.commodity, process.amount);
            if(response.getType() == ResponseType.buysell)
            {
                success = true;
                MBuySell resp = (MBuySell)response;
                process.id = resp.getID();
            }
            next(process, success);
            return response;
            
        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.last;
                process.step(1);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(1);
            }
        }
    }


    public class SellAction : InnerLogic
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public object run(LogicProcess process)
        {
            bool success = false;
            IMarketResponse response = process.comm.SendSellRequest(process.price, process.commodity, process.amount);
            if (response.getType() == ResponseType.buysell)
            {
                success = true;
                MBuySell resp = (MBuySell)response;
                process.id = resp.getID();
            }
            next(process, success);
            return response;

        }

        private void next(LogicProcess process, bool success)
        {
            if (success)
            {
                process.queue = LogicQueue.last;
                process.step(1);
            }
            else
            {
                process.queue = LogicQueue.last;
                process.step(1);
            }
        }
    }

}
