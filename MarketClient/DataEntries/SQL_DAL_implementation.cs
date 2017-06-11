using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MarketClient.DataEntries
{
    public class SQL_DAL_implementation 
    {
        private historyDataContext db;

        public SQL_DAL_implementation()
        {
            db = new historyDataContext();
        }

        private IQueryable<item> itemsByNumDays(DateTime start, DateTime end)
        {//return the prices in the asked dates 
            IQueryable<item> itemsInRange =
                from item in db.items
                where item.timestamp > start && item.timestamp <end
                select item
                ;
            return itemsInRange;
        }

        public float PriceAverage(DateTime start,DateTime end ,int commodity)
        {//return the average price in the asked days
            IQueryable<item> itemsInRange =
                itemsByNumDays(start, end).Where(db => db.commodity == commodity);
            float avg = itemsInRange.Average(db => db.price);
            return avg;
        }

        public item highestSell(DateTime start, DateTime end, int commodity)
        {//return the highst price in the asked days
            IQueryable<item> itemsInRange = itemsByNumDays(start, end).Where(db => db.commodity == commodity);
            float max = itemsInRange.Max(q => q.price);
            item highestPrice = itemsInRange.Where(q => q.price == max).First();
            return highestPrice;
        }

        public int numOfHighest(DateTime start, DateTime end, int commodity)
        {//return the number time of the highest price bought  
            IQueryable<item> itemsInRange = itemsByNumDays(start, end).Where(db => db.commodity == commodity);
            float highestPrice = highestSell(start,end,commodity).price;
            int amount = itemsInRange.Count(db => db.price == highestPrice);
            return amount;
            
        }

        public item lowestSell(DateTime start, DateTime end, int commodity)
        {
            IQueryable<item> itemsInRange = itemsByNumDays(start,end).Where(db => db.commodity == commodity);
            float min = itemsInRange.Min(q => q.price);
            item lowest = itemsInRange.OrderBy(db => db.price).First();
            return lowest;
        }

        public int numOfLowest(DateTime start, DateTime end, int commodity)
        {//return the number time of the lowest price bought  
            IQueryable<item> itemsInRange = itemsByNumDays(start, end).Where(db => db.commodity == commodity);
            float lowestPrice = lowestSell(start, end,commodity).price;
            int amount = itemsInRange.Count(db => db.price == lowestPrice);
            return amount;
        }

        public float[] avgPerhour(DateTime start, DateTime end, int commodity)
        {//return each day the avg price of the commodity
            IQueryable<item> itemsInRange = itemsByNumDays(start, end).Where(db => db.commodity == commodity);
            int arraySize = end.Hour-start.Hour;
            float[] output = new float[arraySize];
            for (int i = 0; i<arraySize; i++)
            {
                int hour = start.Day + i;
                float avg = itemsInRange.Where(db => db.timestamp.Day == hour).Average(db => db.price);
                output[i] = avg;
            }
            return output;
        }

    }
}
