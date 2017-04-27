using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public enum LogicQueue {first, last, none}

    /*DynamicLogic*/
    public class DynamicLogic
    {
        //ICommunicator comm = new Communicator();

        //private LogicQueue queue;
        private innerLogicMethod innerLogic;
        private birthLogicMethod nextLogic;
        private birthLogicMethod prevLogic;

        private int commodity;
        private int price;
        private int amount;
        private int id;

        private LogicQueue queue
        {
            get
            {
                return queue;
            }

            set
            {
                queue = value;
            }
        }

        public DynamicLogic(LogicQueue queue, innerLogicMethod innerLogic, 
            birthLogicMethod nextLogic, birthLogicMethod prevLogic, 
            int commodity, int price, int amount, int id)
        {
            this.queue = queue;
            this.innerLogic = innerLogic;
            this.nextLogic = nextLogic;
            this.prevLogic = prevLogic;
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.id = id;
        }

        public DynamicLogic run()
        {
            bool success = innerLogic.run(commodity, price, amount, id);
            if (success)
                return nextLogic.run(commodity, price, amount, id);
            else
                return prevLogic.run(commodity, price, amount, id);
        }
    }


    /*Interfaces for methods*/
    
    public interface BirthLogicMethod
    {
        DynamicLogic run();
    }


    

}
