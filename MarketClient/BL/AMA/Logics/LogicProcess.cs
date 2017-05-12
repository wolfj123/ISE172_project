using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MarketClient.BL
{
    public enum LogicQueue {first, last, none}

    public class LogicProcess
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public List<InnerLogic> list;
        public LogicQueue queue;
        public int currIndex;
        public bool repeat;

        public ICommunicator comm;
        public int commodity;
        public int price;
        public int amount;
        public int id;

        public SpecialAction spec;

        public LogicProcess(bool repeat, ICommunicator comm, int commodity, 
            int price, int amount, int id)
        {
            list = new List<InnerLogic>();
            this.queue = LogicQueue.first;
            this.currIndex = 0;
            this.repeat = repeat;

            this.comm = comm;
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.id = id;

            this.spec = null;
        }

        public virtual LogicProcess run()
        {
            list.ElementAt(currIndex).run(this);
            runSpec();
            return this;
        }


        //Used for further enhancing the logicProcess and testing
        public void addSpecialAction(SpecialAction spec)
        {
            this.spec = spec;
        }

        private object runSpec()
        {

            if (spec != null)
            {
                myLogger.Info("Logic Action: Special action");
                return spec.runSpecial();
            }
            else
                return null;
        }

        //Go to the next step in the logic process
        public void step(int step)
        {
            currIndex += step;
            if (currIndex >= list.Count)
            {
                currIndex = 0;
                if (!repeat)
                    queue = LogicQueue.none;
            }

        }
    }


    public interface SpecialAction
    {
        object runSpecial();
    }


    public class BuyProcess : LogicProcess
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public BuyProcess(bool repeat, ICommunicator comm, int commodity, 
            int price, int amount, int id) : 
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new hasExistingRequest());
            //list.Add(new BidCompare());
            list.Add(new AskCompare());
            list.Add(new BuyAction());

            myLogger.Info("Created new BuyProcess: {Commodity: " + commodity + ", Price: " + price + ", Amount: " + amount + ", Repeat: " + repeat+ "}");
        }

        public override string ToString()
        {
            return "Buy " + amount + " of commodity " + commodity + " when the 'Ask' is equal or below " + price;
        }

    }

    public class SellProcess : LogicProcess
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public SellProcess(bool repeat, ICommunicator comm, int commodity,
            int price, int amount, int id) :
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new hasExistingRequest());
            list.Add(new hasCommodity());
            //list.Add(new AskCompare());
            list.Add(new BidCompare());
            list.Add(new SellAction());

            myLogger.Info("Created new SellProcess: {Commodity: " + commodity + ", Price: " + price + ", Amount: " + amount + ", Repeat: " + repeat + "}");
        }

        public override string ToString()
        {
            return "Sell " + amount + " of commodity " + commodity + " when the 'Bid' is equal or above " + price;
        }
    }

}
