using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries
{
    public static class HistoryView
    {
        public static String[] historyByDate(DateTime dateLimit)
        {
            //read the history file
            string[] lines = System.IO.File.ReadAllLines(@"../../../History/history.log");
            if (lines.Length > 0)
            {
                //if there are history in the text return the cuurect history
                //run over the txt from the end to the start
                int counter = 0;
                int lineNumber = lines.Length - counter;
                String[] splitLine = lines[lineNumber].Split(' ');
                int day = int.Parse(splitLine[0]);
                int month = int.Parse(splitLine[1]);
                int year = int.Parse(splitLine[2]);
                DateTime Historydate = new DateTime(year, month, day);
                while (counter >= 0 && Historydate < dateLimit)
                {//find all the history in the range
                    counter++;
                    lineNumber = lines.Length - counter;
                    splitLine = lines[lineNumber].Split(' ');
                    day = int.Parse(splitLine[0]);
                    month = int.Parse(splitLine[1]);
                    year = int.Parse(splitLine[2]);
                    Historydate = new DateTime(year, month, day);
                }
                String[] output = new String[counter];
                if (counter > 0)
                {//copy the history in the range into output array
                    for (int i = lines.Length; i < counter; i--)
                        output[i] = lines[i];
                }
                return output;
            }
            return null;
        }

        public static String[] historyBydays(int daysNumber)
        {
            DateTime currentDate = DateTime.Now;
            DateTime dateLimit = currentDate.AddDays(-daysNumber);
            return historyByDate(dateLimit);

        }
    }
}
