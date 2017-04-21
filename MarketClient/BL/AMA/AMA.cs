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
            int count = 0;
            while (count < maxReq & blocks.Count > 0)
            {
                //Take out and remove first logic block
                LogicBlock currentLogic = blocks[0];
                blocks.RemoveAt(0);

                //if it should be repeated - add it to the end of the list
                if (currentLogic.isRepeated())
                    blocks.Add(currentLogic);

                //run the logic block
                object output = currentLogic.run();

                //if the output is another logic block - add it to the top of the list
                if (output is LogicBlock)
                {
                    LogicBlock newLogic = (LogicBlock)output;
                    blocks.Insert(0, newLogic);
                }

                if(output is List<LogicBlock>)
                {
                    List<LogicBlock> newLogics = (List<LogicBlock>)output;
                    foreach(LogicBlock logic in newLogics)
                    {
                        blocks.Insert(0, logic);
                    }
                }
                count++;
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
