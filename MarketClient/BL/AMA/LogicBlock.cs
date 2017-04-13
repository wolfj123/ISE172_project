using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class LogicBlock
    {

        private LogicCondition cond;
        private LogicAction act;
        

        public LogicBlock(LogicCondition cond, LogicAction act)
        {
            this.cond = cond;
            this.act = act;
        }

        public bool isMet()
        {
            return cond.isMet();
        }


        public void action()
        {
            act.action();
        }

        public int getConditionCost()
        {
            return cond.requestCost();
        }

        public int getActionCost()
        {
            return act.requestCost();
        }


    }




}
