using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;

namespace MarketClientTest
{
    [TestClass]
    public class AdvancedAMAgatherInfoTest
    {
        [TestMethod]
        public void AdvancedAMAgatherInfoTestMethod()
        {
            //Setup communicatro stub
            List<MQCommodityWrapper> mqCommodityWrapper = new List<MQCommodityWrapper>();
            List<MQReqWrapper> mqReqyWrapper = new List<MQReqWrapper>();
            MQUser mqUser = new MQUser();
            CommStubStaticReturn comm = new CommStubStaticReturn();

            comm.qAllmarket = mqCommodityWrapper;
            comm.qAllrequests = mqReqyWrapper;
            comm.quser = mqUser;

            //Run AMA for a while
            AdvancedAMA agent = new AdvancedAMA(3, 10000, comm);
            agent.enable(true);
            System.Threading.Thread.Sleep(1000);
            agent.enable(false);


            //Verify if AMA has collected the info from the communicator stub
            Assert.AreEqual(mqCommodityWrapper, agent.commoditiesInfo);
            Assert.AreEqual(mqReqyWrapper, agent.requestsInfo);
            Assert.AreEqual(mqUser, agent.userData);
        }
    }
}
