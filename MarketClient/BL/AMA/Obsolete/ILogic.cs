using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CURRENTLY OBSOLETE


namespace MarketClient.BL
{
    public interface LogicCondition
    {
        bool isMet();
    
        int requestCost();
    }


    public interface LogicAction
    {
        void action();

        int requestCost();
    }
}
