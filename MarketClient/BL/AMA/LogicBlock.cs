using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{

    public interface LogicBlock
    {
        void run();

        bool conditionIsMet();

        int actionReqCount();

        int conditionReqCount();

    }




    public class BidBuy : LogicBlock
    {

        /* TODO: 
         * this object should send a query for a commodity and if the bid is a lower than a threshold send a buy request
         */

        private int commodity;
        private int bid;
        private IMarketResponse response;

        public BidBuy(int commodity, int bid)
        {

        }





    }

    public class AskSell : LogicBlock
    {
        


        public AskSell(int commodity, int ask)
        {

        }


        private IMarketResponse


    }



    /*
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

    */


}
