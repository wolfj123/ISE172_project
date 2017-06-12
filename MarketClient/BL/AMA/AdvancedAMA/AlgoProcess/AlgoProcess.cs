using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MarketClient.BL
{
    //An object composed of a list of conditions and an action
    //If all the conditions are met than the action is initiated
    public class AlgoProcess
    {

        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public AdvancedAMA agent;
        public ICommunicator comm;
        public int commodity;
        public List<AlgoCondition> conditions;
        public AlgoAction action;
        public int requestID;
        string name = "AlgoProcess";

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
            if (agent.requestsInfo == null) return;

            List<MQReqWrapper> list = agent.requestsInfo;

            bool containsRequest = false;
            for (int i=0; i<list.Count & !containsRequest; i++)
            {
                MQReqWrapper current = list[i];
                if (current.id == this.requestID)
                    containsRequest = true;
            }

            if (!containsRequest)
            {
                requestID = -1;
            }
            
        }


        public virtual bool runProcess()
        {
            updateRequestStatus();       

            //Verify that all conditions are met
            bool conditionsMet = true;
            if (conditions.Count > 0)
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
                myLogger.Info(name + " conditions are met");
                action.runAction(this);
                myLogger.Info(name + " has activated the action");
                return true;
            }
            else
            {
                myLogger.Info(name + " conditions are not met");
                return false;
            }
        }

        public override string ToString()
        {
            string output = name + " info:\nCommodity ID: "+commodity+"\nConditions: ";
            foreach(AlgoCondition c in conditions)
            {
                output += c.ToString();
                output += ", ";
            }
            output += "\nAction: " + action.ToString();
            return output;
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
