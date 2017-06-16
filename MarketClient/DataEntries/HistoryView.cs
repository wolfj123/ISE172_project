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
            //take date parameters for the name of the file 
            DateTime today = DateTime.Now;
            String todayYear = today.Year.ToString();
            String todayMonth = today.Month.ToString();
            if (today.Month < 10)
            {//if the month is less then 10 then add 0 befor the number
                todayMonth = "0" + todayMonth;
            }
            List<String> output = new List<String>();
            using (StreamReader sr = new StreamReader("../../../History/" + todayYear + "." + todayMonth + "History.log"))
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
                    {//do nothing
                    }
                }
                //copy all the history in range into output
                while (line != null && historyDate <= maxDate)
                {
                    try
                    {
                        historyDate = getDate(line);
                        output.Add(line);
                    }
                    catch
                    {
                        //the file reader dont read the full line so he split the lines while reading
                        //this is desingded to marge the lines if they were splited
                        int indexString = output.Count() -1;
                        String fullLine = output.ElementAt(indexString ) +" " + line;
                        output.RemoveAt(indexString);
                        output.Add(fullLine);
                    }
                    line = sr.ReadLine();
                }
                
            }
            String[] historyInRange = new String[output.Count];
            int index = output.Count-1;
            //copy the output into an array
            foreach (String e in output)
            {
                historyInRange[index] = e;
                index--;
            }
            return historyInRange;
        }

        public static String[] historyByLines(int numRows)
        {
            //the variabels for the history file name
            DateTime today = DateTime.Now;
            String todayYear = today.Year.ToString();
            String todayMonth = today.Month.ToString();
            if(today.Month < 10)
            {//if the month is less then 10 then add 0 befor the number
                todayMonth = "0" + todayMonth;
            }
            List<String> output = new List<String>();
            using (StreamReader sr = new StreamReader("../../../History/" + todayYear + "." + todayMonth + "History.log"))
            {
                string line = sr.ReadLine();
                //check that the file isnt empty
                if (line == null)
                    return null;
                DateTime currentDate;
                while (line != null)
                { //insert all the file contant into a string list
                    try
                    {
                        currentDate = getDate(line);
                        output.Add(line);
                    }
                    catch
                    {
                        //the file reader dont read the full line so he split the lines while reading
                        //this is desingded to marge the lines if they were splited
                        int indexString = output.Count() - 1;
                        String fullLine = output.ElementAt(indexString) + line;
                        output.RemoveAt(indexString);
                        output.Add(fullLine);
                    }
                    line = sr.ReadLine();
                }
            }
            //copy the list into an array
            String[] historyLines = new string[output.Count];
            for(int i = 0; i<numRows && i<output.Count; i++)
            {
                int outputIndex = output.Count - 1 - i;
                historyLines[i] =output.ElementAt(outputIndex);
            }
            return historyLines;
        }

        private static DateTime getDate(String str)
        {//input string returns the string as a date variable
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
        {//return the history by num od days backwards
            DateTime currentDate = DateTime.Now;
            DateTime dateLimit = currentDate.AddDays(-daysNumber);
            return historyByDate(dateLimit, currentDate);
        }

        public static void deleteHistory()
        {//delete the content in the history file
            System.IO.File.WriteAllText("../../../ History/history2.log", string.Empty);
        }

    }
}
