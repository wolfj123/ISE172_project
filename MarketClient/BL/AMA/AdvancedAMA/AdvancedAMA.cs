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
    public class AdvancedAMA
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        protected Queue<AlgoProcess> queue; //The list containing all the LogicBlocks
        protected int maxReq; //The maximum requests allowed per interval
        protected System.Timers.Timer aTimer;
        protected ICommunicator comm;

        //Info gathered from the server
        public MQUser userData;
        public List<MQCommodityWrapper> commoditiesInfo;
        public List<MQReqWrapper> requestsInfo;

        public AdvancedAMA(int maxReq, double interval, ICommunicator comm)
        {
            this.comm = comm;
            this.maxReq = maxReq;
            queue = new Queue<AlgoProcess>();

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
                int count = gatherInfo();
                while (count < maxReq)
                {
                    bool sentRequest = run();
                    if (sentRequest) count = count + 1;
                }


            }).Start();

        }

        public int gatherInfo()
        {
            int numOfReqeusts = 0;

            //backup
            MQUser oldUserData = userData;
            List<MQCommodityWrapper> oldCommoditiesInfo = commoditiesInfo;
            List<MQReqWrapper> oldRequestsInfo = requestsInfo;


            //Gather data from the server
            try
            {
                userData = (MQUser)comm.SendQueryUserRequest();    numOfReqeusts++;
            }
            catch (Exception e)
            {
                userData = oldUserData;
                myLogger.Error("AMA failed to acquire userData: "+e.Message);
            }

            try
            {
                commoditiesInfo = comm.SendQueryAllMarketRequest(); numOfReqeusts++;
            }
            catch (Exception e)
            {
                commoditiesInfo = oldCommoditiesInfo;
                myLogger.Error("AMA failed to acquire commoditiesInfo: " + e.Message);
            }

            try
            {
                requestsInfo = comm.SendQueryAllUserRequest(); numOfReqeusts++;
            }
            catch (Exception e)
            {
                requestsInfo = oldRequestsInfo;
                myLogger.Error("AMA failed to acquire requestsInfo: " + e.Message);
            }
            //return number of requests in this method
            return numOfReqeusts;
        }

        public bool run()
        {
            //for (int count=0; count < maxReq & blocks.Count>0; count++) { 
            if (queue.Count > 0)
            {
                //Take out next AlgoProcess from Queue
                AlgoProcess currentLogic = queue.Dequeue();

                //run the process
                bool success = currentLogic.runProcess();
                myLogger.Info("AMA running logic: "+ currentLogic.ToString());

                //Add the AlgoProcess to the end of the queue
                queue.Enqueue(currentLogic);

                return success;
            }
            return false;
        }

        public void enable(bool toEnable)
        {
            aTimer.Enabled = toEnable;
            myLogger.Info("AMA enable set to" + toEnable);

            OnTimedEvent(null, null);
        }

        public bool isEnabled()
        {
            return aTimer.Enabled;
        }


        public virtual void add(AlgoProcess processList)
        {
            queue.Enqueue(processList);
        }

        public void clearLogic()
        {
            queue.Clear();
        }

        public override string ToString()
        {
            string output = "Current rules queue:\n\n";
            int count = 0;
            foreach (AlgoProcess logic in queue)
            {
                count++;
                output += "Rule #" + count + ": ";
                output += logic.ToString();
                output += "\n\n";
            }
            return output;
        }
    }
}
