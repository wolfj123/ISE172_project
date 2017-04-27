using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    /*These classes contains abstract LogicBlock that run independently of a Database
    */

    public abstract class BasicLogic : LogicBlock
    {
        protected BasicLogic parent;
        protected int commodity;
        protected int price;
        protected int amount;

        public BasicLogic(ICommunicator comm, bool repeat, BasicLogic parent, int commodity, int price, int amount)
            : base(comm, repeat)
        {
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.parent = parent;
        }

        protected bool hasParent()
        {
            return parent != null;
        }

        protected BasicLogic getParent()
        {
            return parent;
        }

        public abstract override object run();

        protected abstract BasicLogic createChild(bool next);
    }

    public abstract class BasicAction : BasicLogic
    {
        protected int id;

        public BasicAction(ICommunicator comm, int commodity, int price, int amount)
            : base(comm, false, null, commodity, price, amount)
        {
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.id = -1;
        }

        public override object run()
        {
            bool next = false;
            IMarketResponse response = doAction();

            if (response.getType() == ResponseType.buysell)
            {
                this.id = ((MBuySell)response).getID();
                next = true;
            }
            
            return createChild(next);
        }

        protected abstract IMarketResponse doAction();
    }

    public abstract class BasicCompare : BasicLogic
    {
        public BasicCompare(ICommunicator comm, int commodity, int price, int amount)
            : base(comm, false, null, commodity, price, amount)
        {
        }

        public override object run()
        {
            bool next = false;
            IMarketResponse response = comm.SendQueryMarketRequest(commodity);

            if (response.getType() == ResponseType.qcommodity)
            {
                next = doCompare((MQCommodity)response);
            }

            return createChild(next);
        }

        protected abstract bool doCompare(MQCommodity response);
    }

    public abstract class BasicStatusCheck : BasicLogic
    {
        protected int id;

        public BasicStatusCheck(ICommunicator comm, int commodity, int price, int amount)
            : this(comm, commodity, price, amount, -1)
        {
        }

        public BasicStatusCheck(ICommunicator comm, int commodity, int price, int amount, int id) 
            : base(comm, false, null, commodity, price, amount)
        {
            this.id = id;
        }

        protected bool hasPendingRequest()
        {
            if(id > -1)
            {
                IMarketResponse response = comm.SendQueryBuySellRequest(id);

                if (response.getType() == ResponseType.qreq)
                    return true;
            }
            return false;
        }

        public override object run()
        {
            bool next = !hasPendingRequest();

            return createChild(next);
        }
    }

}
