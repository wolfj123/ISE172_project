﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using MarketClient.PL_BL;

namespace MarketClientTest
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void testEnum()
        {
            MQReq mqreq = new MQReq();
            Trace.WriteLine(mqreq.getType() == ResponseType.qreq);
        }
    }
}