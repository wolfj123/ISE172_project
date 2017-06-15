using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient.DataEntries;
using System.Diagnostics;

namespace MarketClientTest
{
    [TestClass]
    public class TestSQLStuff
    {
        [TestMethod]
        public void TestSQLStuffMethod()
        {
            SQL_DAL_implementation sql = new SQL_DAL_implementation();

            int minTime = 9;
            int medTime = 10;
            int maxTime = 100;


            DateTime minTimeRange = DateTime.Now.AddHours(-minTime);
            float minAverage = sql.PriceAverage(minTimeRange, DateTime.Now, 0);

            DateTime medTimeRange = DateTime.Now.AddHours(-medTime);
            float medAverage = sql.PriceAverage(medTimeRange, DateTime.Now, 0);

            DateTime maxTimeRange = DateTime.Now.AddHours(-maxTime);
            float maxAverage = sql.PriceAverage(maxTimeRange, DateTime.Now, 0);

            Console.WriteLine(minAverage);
            Console.WriteLine(medAverage);
            Console.WriteLine(maxAverage);

        }
    }
}
