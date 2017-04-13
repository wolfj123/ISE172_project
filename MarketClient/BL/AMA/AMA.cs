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

        private bool enabled;
        private List<LogicBlock> blocks; //The list containing all the LogicBlocks
        private int maxReq; //The maximum requests allowed per interval
        private int currentReqCost; //The number of request sent in the time interval
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

            // Start the timer
            aTimer.Enabled = true;

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {




            currentReqCost = 0;
        }



        public void add(LogicBlock block)
        {



        }

        public void clearLogic()
        {


        }


        public void run()
        {
            while (enabled)
            {









            }



        }

        private LogicBlock nextBlock()
        {




        }

        public bool isEnabled()
        {
            return enabled;
        }

        public void enable(bool toEnable)
        {
            enabled = toEnable;
            run();
        }

    }
}
