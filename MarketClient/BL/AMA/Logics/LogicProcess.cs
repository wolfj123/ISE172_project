using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public enum LogicQueue {first, last, none}

    public class LogicProcess
    {
        public List<InnerLogic> list;
        public LogicQueue queue;
        private int currIndex;
        public bool repeat;

        public ICommunicator comm;
        public int commodity;
        public int price;
        public int amount;
        public int id;

        public LogicProcess(bool repeat, ICommunicator comm, int commodity, 
            int price, int amount, int id)
        {
            this.queue = LogicQueue.first;
            this.currIndex = 0;
            this.repeat = repeat;
            this.comm = comm;
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.id = id;
        }

        public LogicProcess run(ICommunicator comm, int commodity, int price, 
            int amount, int id)
        {
            list.ElementAt(currIndex).run(this);
            return this;
        }


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

    public class BuyProcess : LogicProcess
    {
        public BuyProcess(bool repeat, ICommunicator comm, int commodity, 
            int price, int amount, int id) : 
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new hasExistingRequest());
            list.Add(new BidCompare());
            list.Add(new BuyAction());
        }
    }

    public class SellProcess : LogicProcess
    {
        public SellProcess(bool repeat, ICommunicator comm, int commodity,
            int price, int amount, int id) :
            base(repeat, comm, commodity, price, amount, id)
        {
            list.Add(new hasExistingRequest());
            list.Add(new hasCommodity());
            list.Add(new AskCompare());
            list.Add(new SellAction());
        }
    }

}
