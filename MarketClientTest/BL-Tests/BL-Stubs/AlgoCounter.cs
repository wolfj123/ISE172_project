﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;
using System.Diagnostics;

namespace MarketClientTest
{
    //AlgoProcess counter Stub
    public class AlgoCountProcess : AlgoProcess
    {
        public int count;

        public AlgoCountProcess() : this(null, null, 0)
        {
        }

        public AlgoCountProcess(int commodity) : this(null, null, commodity)
        {
        }

        public AlgoCountProcess(AdvancedAMA agent, ICommunicator comm, int commodity) : base(agent,comm, commodity)
        {
            this.setAction(new AlgoCountAction());
        }

    }


    public class AlgoCountAction : AlgoAction
    {
        public bool runAction(AlgoProcess process)
        {
            if (process is AlgoCountProcess)
            {
                AlgoCountProcess countProcess = (AlgoCountProcess)process;
                countProcess.count += 1;
                Trace.WriteLine("Process activation #" + countProcess.count);
                return true;
            }
            else return false;
        }
    }
}
