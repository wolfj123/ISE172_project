using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.BL;
using System.Collections.Generic;


namespace MarketClientTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<LogicProcess> list = new List<LogicProcess>();
            for (int i=0; i<10; i++)
            {
                list.Add(new LogicProcessStub(true,null,i,0,0,0));
            }



            for(int i =0; i<20; i++)
            {

                LogicProcess curr = list[0];
                list.RemoveAt(0);


                Random random = new Random();
                int randomNumber = random.Next(0, 100);

                list.Insert(0, curr);

                /*
                if (randomNumber < 50)
                {
                    list.Add(curr);
                }
                else
                {
                    list.Insert(0, curr);
                }

                */
                Trace.WriteLine(list.ToString());

            }


        }


    }


    public class LogicProcessStub : LogicProcess
    {
        public LogicProcessStub(bool repeat, ICommunicator comm, int commodity, int price, int amount, int id) : base(repeat, comm, commodity, price, amount, id)
        {
        }

        public override string ToString()
        {
            return this.commodity.ToString();
        }
    }
}
