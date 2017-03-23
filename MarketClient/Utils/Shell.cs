using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.Utils
{
    static public class Shell
    {
        static public bool isNumeric(String s)
        {
            int i = 0;
            return int.TryParse(s, out i);
        }



        static public String EnumarableToString(IEnumerable<Object> list)
        {
            
        }



        //Maybe we can make a method for all IEnumerable...
        static public String StringListToString(IEnumerable<String> list)
        {

            String output = "";
            foreach (String str in list)
            {
                output += str + ", ";
            }

            return output;

        }

        static public String intListToString(IEnumerable<int> list)
        {
            String output = "";
            foreach (int i in list)
            {
                output += i.ToString() + ", ";
            }

            return output;

        }

        /*
        static private String ArrayToString(String[] arr)
        {
            String output = "";
            for(int i=0; i<arr.Length; i=i+1)
            {
                output += arr[i];
                if (i < arr.Length - 1)
                    output += ", ";
            }

            return output;

        }

        static private String ArrayToString(int[] arr)
        {
            String output = "";
            for (int i = 0; i < arr.Length; i = i + 1)
            {
                output += arr[i].ToString();
                if (i < arr.Length - 1)
                    output += ", ";
            }
            return output;
        }

        */

    }
}
