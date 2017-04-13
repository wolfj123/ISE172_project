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

        public int run()
        {
            int cost = cond.requestCost();

            if (cond.isMet())
            {
                act.run();
                cost = act.requestCost();
            }

            return cost;
        }



    }




}
