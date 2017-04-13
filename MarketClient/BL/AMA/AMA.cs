using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MarketClient.BL
{

    /*Should have a list of logic blocks
     * 
     * can run and manage the usage of blocks by their request cost
     * (the number of requests that must be sent to the server)
     * 
     */
    public class AMA
    {
        private List<LogicBlock> blocks; //The list containing all the LogicBlocks
        private int maxReq; //The maximum requests allowed per interval
        private System.Timers.Timer aTimer;

        public AMA(int maxReq, double interval)
        {
            this.maxReq = maxReq;
            blocks = new List<LogicBlock>();

            aTimer = new System.Timers.Timer();
            aTimer.Interval = interval;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Do not initiate the timer
            aTimer.Enabled = false;

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if(blocks.Count>0)
                run();
        }

        public void run()
        {
            int currentReqCost = 0;
            while (currentReqCost <= maxReq & blocks.Count>0)
            {
                //stores the first LogicBlock and moves it to the end of the list
                LogicBlock currentBlock = blocks[0];
                blocks.RemoveAt(0);
                blocks.Add(currentBlock);

                bool doAction = false;

                //verify if the condition cost will not exceed the maximum
                if(currentReqCost + currentBlock.getConditionCost() <= maxReq)
                {
                    doAction = currentBlock.isMet();
                    currentReqCost += currentBlock.getConditionCost();
                }

                //verify if the action cost will not exceed the maximum
                if (doAction) 
                    if(currentReqCost + currentBlock.getActionCost() <= maxReq)
                    {
                        currentBlock.action();
                        currentReqCost += currentBlock.getActionCost();
                    }
            }

        }

        public bool isEnabled()
        {
            return aTimer.Enabled;
        }

        public void enable(bool toEnable)
        {
            aTimer.Enabled = toEnable;
        }

        public void add(LogicBlock block)
        {
            blocks.Add(block);
        }

        public void clearLogic()
        {
            blocks.Clear();
        }






    }
}
