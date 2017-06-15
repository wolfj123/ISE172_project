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
            int todayYear = today.Year;
            int todayMonth = today.Month;            
            // if the file didnt delete pervious time delete him
            if (System.IO.File.Exists("../../../History/" + todayYear +".0"+ todayMonth +"history2.log"))
            {
                System.IO.File.Delete("../../../History/" + todayYear + ".0" + todayMonth + "history2.log");
            }
            //copy the history file, read from the copy and at the end delete it 
            System.IO.File.Copy("../../../History/" + todayYear + ".0" + todayMonth + "history.log", "../../../History/" + todayYear + ".0" + todayMonth + "history2.log");        
            List<String> output = new List<String>();
            using (StreamReader sr = new StreamReader("../../../History/" + todayYear + ".0" + todayMonth + "History/history2.log"))
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

                //copy all the history in range into output
                while (line != null && historyDate <= maxDate)
                {
                    output.Add(line);
                    line = sr.ReadLine();
                    try
                    {
                        historyDate = getDate(line);
                    }
                    catch
                    {
                        //insert the end of the history log into the previous history log
                        int indexString = output.Count() -1;
                        String fullLine = output.ElementAt(indexString ) + line;
                        output.RemoveAt(indexString);
                        output.Add(fullLine);
                        line = sr.ReadLine();
                    }
                }
                
            }
            System.IO.File.Delete("../../../History/" + todayYear  +".0"+ todayMonth + "history2.log");
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
            int todayYear = today.Year;
            int todayMonth = today.Month;
            String[] t = new string[3];
            System.IO.File.Create("../../../History/HA.txt");
            t[0]="1: " + todayYear + " , " + todayMonth;

            // if the file didnt delete pervious time delete him
            if (System.IO.File.Exists("../../../History/" + todayYear + "."+ todayMonth + "history2.log"))
            {
                System.IO.File.Delete("../../../History/" + todayYear + "." + todayMonth + "history2.log");
            }
            //copy the history file, read from the copy and at the end delete it 
            System.IO.File.Copy("../../../History/" + todayYear + "." + todayMonth + "history.log", "../../../History/" + todayYear + "." + todayMonth + "history2.log");
            List<String> output = new List<String>();
            using (StreamReader sr = new StreamReader("../../../History/" + todayYear + "." + todayMonth + "History/history2.log"))
            {
                t[1]="2: "+todayYear + " , " + todayMonth;
                string line = sr.ReadLine();
                //check that the file isnt empty
                if (line == null)
                    return null;
                if (output.Count < numRows)
                {
                    output.Add(line);
                }
            }
            //copy the list into an array

            System.IO.File.WriteAllLines("../../../History/HA.txt",t);
            String[] historyLines = new string[output.Count];
            int index = output.Count - 1;
            foreach (String e in output)
            {
                historyLines[index] = e;
                index--;
            }
            return historyLines;
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
            return historyByDate(dateLimit, currentDate);
        }

        public static void deleteHistory()
        {
            System.IO.File.WriteAllText("../../../ History/history2.log", string.Empty);
        }
    }
}
