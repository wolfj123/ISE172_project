using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    //Buy Logics
    public class BasicCheckBuyReq : BasicStatusCheck
    {
        public BasicCheckBuyReq(ICommunicator comm, int commodity, int price, int amount)
            : base(comm, commodity, price, amount, -1)
        {
        }

        public BasicCheckBuyReq(ICommunicator comm, int commodity, int price, int amount, int id)
            : base(comm, commodity, price, amount, id)
        {
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
            {
                setRepeat(false);
                return new BasicAsk(comm, commodity, price, amount);
            }
            else
            {
                setRepeat(true);
                return null;
            }
        }
    }

    public class BasicAsk : BasicCompare
    {
        public BasicAsk(ICommunicator comm, int commodity, int price, int amount)
            : base(comm, commodity, price, amount)
        {
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
            {
                setRepeat(false);
                return new BasicBuy(comm, commodity, price, amount);
            }
            else
            {
                setRepeat(true);
                return null;
            }
        }

        protected override bool doCompare(MQCommodity response)
        {
            return (response.getAsk() <= price);
        }
    }

    public class BasicBuy : BasicAction
    {
        public BasicBuy(ICommunicator comm, int commodity, int price, int amount) 
            : base(comm, commodity, price, amount)
        {
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
                return new BasicCheckBuyReq(comm, commodity, price, amount, id);
            else
                return new BasicCheckBuyReq(comm, commodity, price, amount);
        }

        protected override IMarketResponse doAction()
        {
            return comm.SendBuyRequest(price, commodity, amount);
        }
    }


    //Sell Logics
    public class BasicCheckSellReq : BasicStatusCheck
    {
        public BasicCheckSellReq(ICommunicator comm, int commodity, int price)
            : base(comm, commodity, price, 0, -1)
        {
        }

        public BasicCheckSellReq(ICommunicator comm, int commodity, int price,int id)
            : base(comm, commodity, price, 0, id)
        {
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
            {
                setRepeat(false);
                return new BasicHasCommodity(comm, commodity, price, amount);
            }
            else
            {
                setRepeat(true);
                return null;
            }
        }
    }

    public class BasicHasCommodity : BasicLogic
    {

        public BasicHasCommodity(ICommunicator comm, int commodity, int price, int amount)
            : base(comm, false, null, commodity, price, amount)
        {
        }

        public override object run()
        {
            bool next = false;
            IMarketResponse response = comm.SendQueryUserRequest();
            
            if(response.getType() == ResponseType.quser)
            {
                Dictionary<string, int> commodityList = ((MQUser)response).getCommodities();
                amount = commodityList[commodity.ToString()];
                if (amount > 0)
                    next = true;
            }
            return createChild(next);
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
            {
                setRepeat(false);
                return new BasicBid(comm, commodity, price, amount);
            }
            else
            {
                setRepeat(true);
                return null;
            }
        }
    }

    public class BasicBid : BasicCompare
    {
        public BasicBid(ICommunicator comm, int commodity, int price, int amount) : base(comm, commodity, price, amount)
        {
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
            {
                setRepeat(false);
                return new BasicSell(comm, commodity, price, amount);
            }
            else
            {
                setRepeat(true);
                return null;
            }       
        }

        protected override bool doCompare(MQCommodity response)
        {
            return (response.getBid() >= price);
        }
    }

    public class BasicSell : BasicAction
    {
        public BasicSell(ICommunicator comm, int commodity, int price, int amount) : base(comm, commodity, price, amount)
        {
        }

        protected override BasicLogic createChild(bool next)
        {
            if (next)
                return new BasicCheckBuyReq(comm, commodity, price, amount, id);
            else
                return new BasicCheckBuyReq(comm, commodity, price, amount);
        }

        protected override IMarketResponse doAction()
        {
            return comm.SendSellRequest(price, commodity, amount);
        }
    }





}
