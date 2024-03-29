﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using log4net;

namespace MarketClient.DataEntries
{
    public class HistoryDalImplementation
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        private historyDataContext db;

        public HistoryDalImplementation()
        {
            db = new historyDataContext();
        }

        private IQueryable<item> itemsByNumDays(DateTime start, DateTime end, int commodity)
        {//return the prices in the asked dates 
            start.AddHours(-3);
            end.AddHours(-3);
            IQueryable<item> itemsInRange =
                from item in db.items
                where item.timestamp > start && item.timestamp < end && item.commodity == commodity
                select item
                ;
            return itemsInRange;
        }

        public virtual float PriceAverage(DateTime start, DateTime end, int commodity)
        {//return the average price in the asked days
            try
            {
                IQueryable<item> itemsInRange =
                    itemsByNumDays(start, end,commodity);
                float avg = itemsInRange.Average(db => db.price);
                myLogger.Info("A query of avarage price for " + commodity +" has occurred from history Data Base");
                return avg;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public float PriceAverage(int commodity)
        {//return the avarege price in the last 15 houers
            DateTime end = DateTime.Now;
            DateTime start = end.AddHours(-15);
            return PriceAverage(start, end, commodity);
        }

        public item highestSell(DateTime start, DateTime end, int commodity)
        {//return the highst price in the asked days
            try
            {
                IQueryable<item> itemsInRange = itemsByNumDays(start, end, commodity);
                float max = itemsInRange.Max(q => q.price);
                item highestPrice = itemsInRange.Where(q => q.price == max).First();
                myLogger.Info("A query of avarage price for " + commodity + " has occurred from history Data Base");
                return highestPrice;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public item highestSell(int commodity)
        {//return the highst price in the last 15 houres
            DateTime end = DateTime.Now;
            DateTime start = end.AddHours(-15);
            return highestSell(start, end, commodity);
        }

        public int numOfHighest(DateTime start, DateTime end, int commodity)
        {//return the number time of the highest price bought  
            try
            {
                IQueryable<item> itemsInRange = itemsByNumDays(start, end, commodity);
                float highestPrice = highestSell(start, end, commodity).price;
                int amount = itemsInRange.Count(db => db.price == highestPrice);
                myLogger.Info("A query of num of highst price occur for " + commodity + " from history Data Base");
                return amount;
            }
            catch (Exception e)
            {
                return -1;
            }

        }

        public int numOfHighest(int commodity)
        {//return the number time of the highest price bought in the last 15 houers
            DateTime end = DateTime.Now;
            DateTime start = end.AddHours(-15);
            return numOfHighest(start, end, commodity);
        }

        public item lowestSell(DateTime start, DateTime end, int commodity)
        {//return the lowest sell of the commidity 
            try
            {
                IQueryable<item> itemsInRange = itemsByNumDays(start, end, commodity);
                float min = itemsInRange.Min(q => q.price);
                item lowest = itemsInRange.OrderBy(db => db.price).First();
                myLogger.Info("A query of lowest price for " + commodity +" from history Data Base has occured");
                return lowest;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public item lowestSell(int commodity)
        {//return the lowest sell of the commidity in the last 15 houers
            DateTime end = DateTime.Now;
            DateTime start = end.AddHours(-15);
            return lowestSell(start, end, commodity);
        }

        public int numOfLowest(DateTime start, DateTime end, int commodity)
        {//return the number time of the lowest price bought  
            try
            {
                IQueryable<item> itemsInRange = itemsByNumDays(start, end, commodity);
                float lowestPrice = lowestSell(start, end, commodity).price;
                int amount = itemsInRange.Count(db => db.price == lowestPrice);
                myLogger.Info("A query of number of lowest price for " + commodity + " from history Data Base has occured");
                return amount;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int numOfLowest(int commodity)
        {//return the number time of the lowest price bought in the last 15 houers
            DateTime end = DateTime.Now;
            DateTime start = end.AddHours(-15);
            return numOfLowest(start, end, commodity);
        }

        public float[] avgPerday(DateTime start, DateTime end, int commodity)
        {//return each day the avg price of the commodity
            try
            {
                IQueryable<item> itemsInRange = itemsByNumDays(start, end, commodity);
                int arraySize = end.Day - start.Day;
                float[] output = new float[arraySize];
                for (int i = 0; i < arraySize; i++)
                {
                    try
                    {
                        int hour = start.Day + i;
                        float avg = itemsInRange.Where(db => db.timestamp.Day == hour).Average(db => db.price);
                        output[i] = avg;
                    }
                    catch (Exception e)
                    {
                        output[i] = -1;
                    }
                }
                myLogger.Info("the avarge price per day for " + commodity + " , form the last " + arraySize +
                    "days, from history Data Base has occured");
                return output;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public float[] avgPerday(int commodity)
        {
            DateTime end = DateTime.Now;
            DateTime start = end.AddDays(-7);
            return avgPerday(start, end, commodity);
        }

    }
}

