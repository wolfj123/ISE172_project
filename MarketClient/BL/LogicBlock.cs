using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class LogicBlock
    {
        private LogicCondition condition;
        private LogicAction action;
        

        public LogicBlock(LogicCondition condition, LogicAction action)
        {
            this.condition = condition;
            this.action = action;
        }

    }




}
