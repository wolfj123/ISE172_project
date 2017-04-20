using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public class SimpleBuyCheckStatus : CheckStatus
    {
        private int price;
        private int amount;

        public SimpleBuyCheckStatus(int commodity, int price, int amount, ICommunicator comm, bool repeat)
            : this (commodity,price,amount, -1,comm, repeat)
        {
        }

        public SimpleBuyCheckStatus(int commodity, int price, int amount, int id, ICommunicator comm, bool repeat)
             : base(commodity, id, comm, repeat)
        {
            this.price = price;
            this.amount = amount;
        }

        public override object run()
        {
            if (isPending())
                return null;
            else
            {
                LogicBlock newLogic = new SimpleBuyCondition(commodity, price, amount, this, comm);
                return newLogic;
            }
        }
    }

    public class SimpleBuyCondition : LogicBlock
    {
        private int commodity;
        private int price;
        private int amount;
        private ICommunicator comm;
        private SimpleBuyCheckStatus parent;

        public SimpleBuyCondition(int commodity, int price, int amount,
             SimpleBuyCheckStatus parent, ICommunicator comm)
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

                if (commodityInfo.getAsk() <= price) //If the price is right :)
                {
                    LogicBlock newLogic = new SimpleBuyAction(commodity, price, amount, parent, comm);
                    return newLogic;
                }
            }

            return response;
        }
    }

    public class SimpleBuyAction : LogicBlock
    {
        private int commodity;
        private int price;
        private int amount;
        private ICommunicator comm;
        private SimpleBuyCheckStatus parent;

        public SimpleBuyAction(int commodity, int price, int amount,
                 SimpleBuyCheckStatus parent, ICommunicator comm)
        {
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.comm = comm;
            //this.parent = parent;
        }

        public override object run()
        {
            IMarketResponse response = comm.SendBuyRequest(price, commodity, amount);

            if (response.getType() == ResponseType.buysell)
                parent.setID(((MBuySell)response).getID());

            return response;
        }
    }
}
