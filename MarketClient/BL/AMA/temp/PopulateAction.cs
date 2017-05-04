using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.PL_BL;
using MarketClient.Utils;

namespace MarketClient.BL.AMA
{
    public abstract class PopulateAction : LogicBlock
    {
        private bool loop;
        protected ICommunicator communicator;

        public PopulateAction(ICommunicator communicator)
        {
            this.communicator = communicator;
        }

        public bool repeat()
        {
            return true;
        }

        public void setRepeat(bool loop)
        {
            this.loop = loop;
        }

        public object runBlock()
        {
            return action(null);
        }

        public bool isMet(object obj)
        {
            return true;
        }

        public object ask()
        {
            return null;
        }

        public abstract object action(object obj);

    }



    public class QueryUserData : PopulateAction
    {
        public QueryUserData(ICommunicator communicator) : base(communicator)
        {
        }

        public override object action(object obj)
        {
            IMarketResponse response =  communicator.SendQueryUserRequest();

            if (response is MarketException)
                return response;
            else
            {

            }




        }

    }
}
