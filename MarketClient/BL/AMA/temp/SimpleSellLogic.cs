using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{

    //TODO logic that creates a list of sell checks for all your commodities

    public class SimpleSellListLogic : LogicBlock
    {
        private ICommunicator comm;
        private int price;
        private int amount;
        private LogicBlock[] children;
        

        public SimpleSellListLogic(int price, int amount, int numOfCommodities, ICommunicator comm)
        {
            this.price = price;
            this.amount = amount;
            this.comm = comm;
            children = new LogicBlock[numOfCommodities];
            for (int i=0; i<children.Length; i++)
                children[i] = null;
        }

        public bool hasChild(int commodity)
        {
            if (children[commodity] != null)
                return true;
            else return false;
        }

        public void setChild(int commodity, LogicBlock logic)
        {
            children[commodity] = logic;
        }

        public override object run()
        {
            IMarketResponse response = comm.SendQueryUserRequest();
        }
    }




    public class SimpleSellCheckStatus : CheckStatus
    {
        private int price;
        private int amount;
        private SimpleSellListLogic parent;

        public SimpleSellCheckStatus(int commodity, int price, int amount, ICommunicator comm, bool repeat, SimpleSellListLogic parent)
            : this(commodity, price, amount, -1, comm, repeat, parent)
        {
        }

        public SimpleSellCheckStatus(int commodity, int price, int amount, int id, ICommunicator comm, bool repeat, SimpleSellListLogic parent)
             : base(commodity, id, comm, repeat)
        {
            this.parent = parent;
            this.price = price;
            this.amount = amount;
        }

        public override object run()
        {
            if (isPending())
                return null;
            else
            {
                LogicBlock newLogic = new SimpleSellCondition(commodity, price, amount, this, comm);
                return newLogic;
            }
        }
    }

    public class SimpleSellCondition : LogicBlock
    {
        private int commodity;
        private int price;
        private int amount;
        private ICommunicator comm;
        private SimpleSellListLogic parent;

        public SimpleSellCondition(int commodity, int price, int amount,
             SimpleSellListLogic parent, ICommunicator comm)
        {
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.comm = comm;
            this.parent = parent;
        }

        public override object run()
        {
            IMarketResponse response = comm.SendQueryMarketRequest(commodity);

            if (response.getType() == ResponseType.qcommodity)
            {
                MQCommodity commodityInfo = (MQCommodity)response;

                if (commodityInfo.getBid() >= price) //If the price is right :)
                {
                    LogicBlock newLogic = new SimpleSellAction(commodity, price, amount, parent, comm);
                    return newLogic;
                }
            }

            return response;
        }
    }

    public class SimpleSellAction : LogicBlock
    {
        private int commodity;
        private int price;
        private int amount;
        private ICommunicator comm;
        private SimpleSellCheckStatus parent;

        public SimpleSellAction(int commodity, int price, int amount,
                 SimpleSellCheckStatus parent, ICommunicator comm)
        {
            setRepeat(repeat);
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.comm = comm;
            this.parent = parent;
        }

        public override object run()
        {
            IMarketResponse response = comm.SendSellRequest(price, commodity, amount);

            if (response.getType() == ResponseType.buysell)
                parent.setID(((MBuySell)response).getID());

            return response;
        }
    }
}
