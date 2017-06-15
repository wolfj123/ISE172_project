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

            int minTime = 10;
            int medTime = 100;
            int maxTime = 200;


            DateTime minTimeRange = DateTime.Now.AddDays(-minTime);
            float minAverage = sql.PriceAverage(minTimeRange, DateTime.Now, 0);

            DateTime medTimeRange = DateTime.Now.AddMinutes(-medTime);
            float medAverage = sql.PriceAverage(medTimeRange, DateTime.Now, 0);

            DateTime maxTimeRange = DateTime.Now.AddMinutes(-maxTime);
            float maxAverage = sql.PriceAverage(maxTimeRange, DateTime.Now, 0);

            Console.WriteLine(minAverage);
            Console.WriteLine(medAverage);
            Console.WriteLine(maxAverage);

        }
    }
}
