using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    //An object composed of a list of conditions and an action
    //If all the conditions are met than the action is initiated
    public class AlgoProcess
    {
        public AdvancedAMA agent;
        public ICommunicator comm;
        public int commodity;
        public List<AlgoCondition> conditions;
        public AlgoAction action;
        public int reqeustID;

        public AlgoProcess(AdvancedAMA agent, ICommunicator comm, int commodity) 
            : this(agent,comm,commodity,new List<AlgoCondition>(), null)
        { 
        }

        public AlgoProcess(AdvancedAMA agent, ICommunicator comm, int commodity, 
            List<AlgoCondition> conditions, AlgoAction action)
        {
            this.agent = agent;
            this.comm = comm;
            this.commodity = commodity;
            this.conditions = conditions;
            this.action = action;
        }


        private void updateRequestStatus()
        {
            List<MQReqWrapper> list = agent.requestsInfo;

            bool containsRequest = false;
            for (int i=0; i<list.Count & !containsRequest; i++)
            {
                MQReqWrapper current = list[i];
                if (current.id == this.reqeustID)
                    containsRequest = true;
            }

            if (!containsRequest)
            {
                reqeustID = -1;
            }
            
        }


        public virtual bool runProcess()
        {
            try
            {
                updateRequestStatus();
            }
            catch(Exception e)
            {
                //TODO: log exception
            }
            

            //Verify that all conditions are met
            bool conditionsMet = true;
            if (conditions.Count == 0)
            {
                foreach (AlgoCondition condition in conditions)
                {
                    if (!condition.conditionIsMet(this))
                    {
                        conditionsMet = false;
                        break;
                    }
                }
            }

            //If conditions are met - activate the action and return the result
            if (action == null) return false;
            if (conditionsMet)
            {
                action.runAction(this);
                return true;
            }
            else return false;
        }

        //TODO: update ToString for AlgoProcess
        public override string ToString()
        {
            return base.ToString();
        }

        public void addCondition(AlgoCondition condition)
        {
            conditions.Add(condition);
        }

        public void setAction(AlgoAction action)
        {
            this.action = action;
        }

        public void clearConditions()
        {
            conditions.Clear();
        }
    }
}
