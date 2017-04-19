using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL.AMA
{
    public interface LogicBlock
    { 
        object run();

        bool isRepeated();

        void setRepeat(bool repeat);
    }




    public class BuyCommodityStatus : LogicBlock
    {
        ICommunicator comm;
        bool repeat;

        bool pending;
        int commodity;

        public BuyCommodityStatus(int commodity, ICommunicator comm, bool repeat)
        {
            this.commodity = commodity;
            this.repeat = repeat;
            this.comm = comm;
            this.pending = false;
        }

        public bool isRepeated()
        {
            throw new NotImplementedException();
        }

        public object run()
        {
            throw new NotImplementedException();
        }

        public void setRepeat(bool repeat)
        {
            throw new NotImplementedException();
        }
    }
}
