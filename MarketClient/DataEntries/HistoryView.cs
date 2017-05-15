using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries
{
    public static class HistoryView
    {

        public static String[] historyByDate(DateTime minDate, DateTime maxDate)
        {
            // if the file didnt delete pervious time delete him
            if (System.IO.File.Exists("../../../History/history2.log"))
                System.IO.File.Delete("../../../History/history2.log");
            System.IO.File.Copy("../../../History/history.log","../../../History/history2.log");        
            List<String> output = new List<String>();
            using (StreamReader sr = new StreamReader("../../../History/history2.log"))
            {
                string line = sr.ReadLine();
                //check that the file isnt empty
                if (line == null)
                    return null;
                DateTime historyDate = getDate(line); 
                //look for the history with the first date that in the range
                while (line != null && historyDate < minDate)
                {
                    line = sr.ReadLine();
                    try
                    {
                        historyDate = getDate(line);
                    }
                    catch
                    {
                        line = sr.ReadLine();
                    }
                }
                //if there is two limit on the date
                if (!minDate.Equals(maxDate))
                {
                    //copy all the history in range into output
                    while (line != null && historyDate < maxDate)
                    {
                        output.Add(line);
                        line = sr.ReadLine();
                        try
                        {
                            historyDate = getDate(line);
                        }
                        catch
                        {
                            line = sr.ReadLine();
                        }
                    }
                }
                //if there is only one limit on the date
                else
                {
                    while (line != null)
                    {
                        output.Add(line);
                        line = sr.ReadLine();
                    }
                }
            }
            System.IO.File.Delete("../../../History/history2.log");
            String[] historyInRange = new String[output.Count];
            int index = 0;
            //copy the output into an array
            foreach (String e in output)
            {
                historyInRange[index] = e;
                index++;
            }
            return historyInRange;
        }
            

        private static DateTime getDate(String str)
        {
            if (str == null)
                return new DateTime(1,1,1);
            String[] splitLine = str.Split(' ');
            if (!(int.Parse(splitLine[0]) > 0 || int.Parse(splitLine[0]) < 32))
                throw new Exception ();
            int day = int.Parse(splitLine[0]);
            int month = int.Parse(splitLine[1]);
            int year = int.Parse(splitLine[2]);
            DateTime date = new DateTime(year, month, day);
            return date;
        }



        public static String[] historyBydays(int daysNumber)
        {
            DateTime currentDate = DateTime.Now;
            DateTime dateLimit = currentDate.AddDays(-daysNumber);
            return historyByDate(dateLimit, dateLimit);
        }

        public static void deleteHistory()
        {
            System.IO.File.WriteAllText("../../../ History/history2.log", string.Empty);
        }
    }
}
