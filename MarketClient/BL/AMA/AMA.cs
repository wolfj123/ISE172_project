using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using log4net;
using System.Threading;
using System.Diagnostics;

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
        private static ILog myLogger = LogManager.GetLogger("AMA");

        protected List<LogicProcess> queue; //The list containing all the LogicBlocks
        protected int maxReq; //The maximum requests allowed per interval
        protected System.Timers.Timer aTimer;

        public AMA(int maxReq, double interval)
        {
            this.maxReq = maxReq;
            queue = new List<LogicProcess>();

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
            //create new thread to keep GUI responsive
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                Trace.WriteLine("Timer elapsed");

                //run the max amount of requests
                for (int count = 0; count < maxReq; count++)
                {
                    run(count);
                }

            }).Start();

        }


        public void enable(bool toEnable)
        {
            aTimer.Enabled = toEnable;
            myLogger.Info("AMA enable set to" + toEnable);

            OnTimedEvent(null, null);
        }

        public void run(int count)
        {
                //for (int count=0; count < maxReq & blocks.Count>0; count++) { 
                if (queue.Count > 0)
                {
                    //Take out and remove first logic block
                    LogicProcess currentLogic = queue[0];
                    queue.RemoveAt(0);

                    //run the logic block
                    object output = currentLogic.run();
                    myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Activated - Logic info: " + currentLogic.ToString());
                    //blocks.Add(currentLogic);


                    //decide where to put the logicProcess in the list
                    if (currentLogic.queue == LogicQueue.last)
                    {
                        queue.Add(currentLogic);
                        myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Moved to end of queue");
                    }
                    else if (currentLogic.queue == LogicQueue.first)
                    {
                        queue.Insert(0, currentLogic);
                        myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Moved to start of queue");
                    }
                    else
                    {
                        myLogger.Info("AMA logic " + (count + 1) + "/" + maxReq + ": Discarded");
                    }
                }

        }

        public bool isEnabled()
        {            
            return aTimer.Enabled;
        }


        public virtual void add(LogicProcess block)
        {
            queue.Add(block);
        }

        public void clearLogic()
        {
            queue.Clear();
        }

        public override string ToString()
        {
            string output = "Current rules queue:\n\n";
            int count = 0;
            foreach (LogicProcess logic in queue)
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
        public DefaultAMA(ICommunicator comm) : base(10, 10000)
        {
            for (int commodity = 0; commodity <=6; commodity++)
            {
                this.add(new BuyProcess(true, comm, commodity, 8, 40, -1));
            }
            
            for (int commodity = 0; commodity <= 6; commodity++)
            {
                this.add(new SellProcess(true, comm, commodity, 17, 40, -1));
            }
            
        }
    }



    public class UserAMA : AMA
    {
        private int maxLogics;

        public UserAMA() : base(10, 10000)
        {
            this.maxLogics = 30;
        }

        public override void add(LogicProcess block)
        {

            if (this.queue.Count >= maxLogics)
                throw new Exception("Reached maximum logic capacity for User AMA");
            else
                queue.Add(block);
        }
    }
}
