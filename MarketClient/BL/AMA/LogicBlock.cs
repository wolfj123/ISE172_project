using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL
{
    public abstract class LogicBlock
    {
        protected bool repeat;

        public abstract object run();

        public  bool isRepeated()
        {
            return repeat;
        }

        public void setRepeat(bool repeat)
        {
            this.repeat = repeat;
        }
    }


    public abstract class CheckStatus : LogicBlock
    {
        protected ICommunicator comm;
        protected int id;
        protected int commodity;

        public CheckStatus(int commodity, ICommunicator comm, bool repeat)
            : this(commodity,-1 ,comm,repeat)
        {
        }

        public CheckStatus(int commodity, int id, ICommunicator comm, bool repeat)
        {
            setRepeat(repeat);
            this.commodity = commodity;
            this.comm = comm;
            this.id = id;
        }

        public bool isPending()
        {
            bool pending = false;
            //If there is a pending buy request - check the status
            if (id > -1)
            {
                IMarketResponse response = comm.SendQueryBuySellRequest(id);

                if (response.getType() == ResponseType.qreq) //if response is valid query market request
                    pending = true;
                else
                    id = -1;
            }

            return pending;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public abstract override object run();
    }



}
