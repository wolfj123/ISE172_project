using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries
{
    public static class HistoryView
    {
        public static String[] historyByDate(DateTime minDate, DateTime maxDate)
        {
            String defultPath = "../../../History/history.log";
            return historyByDate(defultPath, minDate, maxDate);

        }

        public static String[] historyByDate(String path, DateTime minDate, DateTime maxDate)
        {
            string[] lines = System .IO.File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                //if there are history in the text return the cuurect history
                //run over the txt lines
                int startIndex = 0;
                String[] splitLine = lines[startIndex].Split(' ');
                int day = int.Parse(splitLine[0]);
                int month = int.Parse(splitLine[1]);
                int year = int.Parse(splitLine[2]);
                DateTime Historydate = new DateTime(year, month, day);
                while(startIndex < lines.Length && Historydate < minDate ){
                    //look for the first line that in the given range
                    splitLine = lines[startIndex].Split(' ');
                    day = int.Parse(splitLine[0]);
                    month = int.Parse(splitLine[1]);
                    year = int.Parse(splitLine[2]);
                    Historydate = new DateTime(year, month, day);
                    startIndex++;
                }
                if (startIndex == lines.Length)
                {
                    //No history in requested range
                    return new String[0];
                }
                int endIndex;
                int outputLenght;
                if (minDate.Equals(maxDate))
                {
                    //if there is only one date given then its only minimum limit
                    endIndex = lines.Length ;
                }
              else
                {
                    endIndex = startIndex;
                    day = int.Parse(splitLine[0]);
                    month = int.Parse(splitLine[1]);
                    year = int.Parse(splitLine[2]);
                    Historydate = new DateTime(year, month, day);
                    while (endIndex < lines.Length && Historydate <= maxDate)
                    {
                        //look for the last line that in the given range
                        splitLine = lines[endIndex].Split(' ');
                        day = int.Parse(splitLine[0]);
                        month = int.Parse(splitLine[1]);
                        year = int.Parse(splitLine[2]);
                        Historydate = new DateTime(year, month, day);
                        endIndex++;
                    }
                }
                outputLenght = endIndex - startIndex;
                String[] output = new String[outputLenght];
                //copy the history in the range into output array
                    for (int i =startIndex , j = 0; i < endIndex; i++ , j++)
                    {
                        output[j] = lines[i];
                    }
                
                return output;
            }
            return null;
        }

        public static String[] historyBydays(int daysNumber)
        {
            String defultPath = "../../../History/history.log";
            return historyBydays(defultPath,daysNumber);
        }

        public static String[] historyBydays(String path,int daysNumber)
        {
            DateTime currentDate = DateTime.Now;
            DateTime dateLimit = currentDate.AddDays(-daysNumber);
            return historyByDate(path, dateLimit, dateLimit);
        }

        public static void deleteHistory()
        {
            String defultPath = "../../../History/history.log";
            deleteHistory(defultPath);
        }

        public static void deleteHistory(String path)
        {
            System.IO.File.WriteAllText(path, string.Empty);
        }
    }
}
