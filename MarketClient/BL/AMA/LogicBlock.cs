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
        protected ICommunicator comm;

        public LogicBlock(ICommunicator comm, bool repeat)
        {
            this.repeat = repeat;
            this.comm = comm;
        }

        public abstract object run();

        public bool isRepeated()
        {
            return repeat;
        }

        public void setRepeat(bool repeat)
        {
            this.repeat = repeat;
        }
    }

}
