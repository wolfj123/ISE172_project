using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MarketClient.BL
{
    //Enum for the repositioning of the Logic Process in the AMA queue
    public enum LogicQueue { first, last, none }

    /// <summary>
    /// A logic process list that is inserted to a queue in the AMA.
    /// each logic process lists all the steps necessary before buying or selling a commodity.
    /// Currently there are 2 types of LogicProcess: BuyProcess/SellProcess
    /// </summary>
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


        //OBSOLETE
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

        //Go to the next step with the privided increment in the logic process based on the success of the previous step
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



    /// <summary>
    /// A logic process that has the following steps:
    /// 1. Verify that there is no existing request from this process
    /// 2. Verify that the commodity's ask price is larger or equal than the specificed price for this process
    /// 3. Send buy request
    /// </summary>
    public class BuyProcess : LogicProcess
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public BuyProcess(bool repeat, ICommunicator comm, int commodity, 
            int price, int amount, int id) : 
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new hasExistingRequest());
            list.Add(new AskCompare());
            list.Add(new BuyAction());

            myLogger.Info("Created new BuyProcess: {Commodity: " + commodity + ", Price: " + price + ", Amount: " + amount + ", Repeat: " + repeat+ "}");
        }

        public override string ToString()
        {
            return "Buy " + amount + " of commodity " + commodity + " when the 'Ask' is equal or below " + price;
        }

    }

    /// <summary>
    /// A logic process that has the following steps:
    /// 1. Verify that there is no existing request from this process
    /// 2. Verify that the commodity is currently in supply by the user for sale
    /// 3. Verify that the commodity's bid price is smaller or equal than the specificed price for this process
    /// 4. Send sell request
    /// </summary>
    public class SellProcess : LogicProcess
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public SellProcess(bool repeat, ICommunicator comm, int commodity,
            int price, int amount, int id) :
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new hasExistingRequest());
            list.Add(new hasCommodity());
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
