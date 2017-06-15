using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.DataEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries.Tests
{
    [TestClass()]
    public class SQL_DAL_implementition
    {
        private SQL_DAL_implementation query;
        private DateTime start;
        private DateTime end;

        [TestInitialize()]
        public void Initialize() {
            query = new SQL_DAL_implementation();
            end = DateTime.Now;
            start = end.AddHours(-25);
        }

        [TestMethod()]
        public void PriceAverageTest()
        {

            for(int i = 0; i<=9; i++)
            {
                Assert.AreNotEqual
                    (-1, query.PriceAverage(start,end,i), "the " + i +" commodiry didnt have avarge");
            }


        }

        [TestMethod()]
        public void highestSellTest()
        {
            for (int i = 0; i <= 9; i++)
            {
                Assert.AreNotEqual(-1,query.highestSell(start, end, i));
            }
        }

        [TestMethod()]
        public void numOfHighestTest()
        {
            for (int i = 0; i <= 9; i++)
            {
                Assert.AreNotEqual(-1,query.numOfHighest(start, end, i));
            }
        }

        [TestMethod()]
        public void lowestSellTest()
        {
            for (int i = 0; i <= 9; i++)
            {
                Assert.IsNotNull(query.lowestSell(start, end, i));
            }
        }

        [TestMethod()]
        public void numOfLowestTest()
        {
            for (int i=0; i <= 9; i++)
            {
                Assert.AreNotEqual(-1, query.numOfLowest(start, end, i));
            }
        }

        [TestMethod()]
        public void avgPerdayTest()
        {
            for(int i = 0; i <= 9; i++)
            {
                query.avgPerday(i);
            }
        }

    }
}