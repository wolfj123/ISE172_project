using System;
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
    public class AMALogicTreeTest
    {
        //[TestMethod]
        
        public void BasicBuyLogicTest()
        {
            AMA testAMA = new AMA(10, 10000);
            ICommunicator commStub = new ICommunicatorStub();
            testAMA.add(new BuyProcess(true, commStub, 1, 1, 1, 1));


            /*
            AMA testAMA = new AMA(10, 10000);
            ICommunicator commStub = new ICommunicatorStub();

            BasicCheckBuyReq buyLogic = new BasicCheckBuyReq(commStub, 1, 2, 5);
            //BasicCheckSellReq sellLogic = new BasicCheckSellReq(commStub, 1, 2, 5);

            testAMA.add(buyLogic); 
            //testAMA.add(sellLogic);

            testAMA.enable(true);

            System.Threading.Thread.Sleep(40000);
            testAMA.enable(false);
            */
        }


        public class PrintLogic : LogicProcess
        {
            public int count;
            public PrintLogic()
                : base(true, null, 0, 0, 0, 0)
            {
                count = 0;
            }

            public override LogicProcess run()
            {
                count = count + 1;
                return null;
            }
        }


    }




}
