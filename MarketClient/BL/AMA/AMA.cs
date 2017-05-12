using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using log4net;

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


        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        protected List<LogicProcess> blocks; //The list containing all the LogicBlocks
        protected int maxReq; //The maximum requests allowed per interval
        protected System.Timers.Timer aTimer;

        public AMA(int maxReq, double interval)
        {
            this.maxReq = maxReq;
            blocks = new List<LogicProcess>();

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
                LogicProcess currentLogic = blocks[0];
                blocks.RemoveAt(0);

                //run the logic block
                object output = currentLogic.run();
                myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Activated");

                //decide where to put the logicProcess in the list
                if (currentLogic.queue == LogicQueue.last)
                {
                    blocks.Add(currentLogic);
                    myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Moved to end of queue");
                }
                else if (currentLogic.queue == LogicQueue.first)
                {
                    blocks.Insert(0, currentLogic);
                    myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Moved to start of queue");
                }
                else
                {
                    myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Discarded");
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
            myLogger.Info("AMA enable set to" + toEnable);

            if (toEnable)
                run();
        }

        public virtual void add(LogicProcess block)
        {
            blocks.Add(block);
        }

        public void clearLogic()
        {
            blocks.Clear();
        }

        public override string ToString()
        {
            string output = "Current rules queue:\n\n";
            int count = 0;
            foreach (LogicProcess logic in blocks)
            {
                count++;
                output += "Rule #" + count+": ";
                output += logic.ToString();
                output +="\n\n";
            }
            return output;
        }

    }



    public class DefaultAMA : AMA
    {
        public DefaultAMA(ICommunicator comm) : base(20, 10000)
        {
            for (int commodity = 0; commodity <=9; commodity++)
            {
                //ICommunicator comm = new TestMarketCommunicator();
                this.add(new BuyProcess(true, comm, commodity, 3, 10, -1));
            }
            for (int commodity = 0; commodity <= 9; commodity++)
            {
                //ICommunicator comm = new TestMarketCommunicator();
                this.add(new SellProcess(true, comm, commodity, 9, 10, -1));
            }
        }
    }



    public class UserAMA : AMA

    {
        private int maxLogics;

        public UserAMA() : base(20, 10000)
        {
        }

        public override void add(LogicProcess block)
        {
            if (this.blocks.Count >= maxLogics)
                throw new Exception("Reached maximum logic capacity for User AMA");
            else
                blocks.Add(block);
        }
    }
}
