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
            int totalReqSent = 0;
            while (totalReqSent <= maxReq & blocks.Count>0)
            {
                //stores the first LogicBlock and moves it to the end of the list
                LogicBlock currentBlock = blocks[0];
                blocks.RemoveAt(0);
                blocks.Add(currentBlock);

                //verify if the next block can be run without flooding the server
                if(totalReqSent + currentBlock.maxReqCount() <= maxReq)
                    totalReqSent += currentBlock.run();
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
