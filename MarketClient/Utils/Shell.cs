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



        //Need to somehow create a function for all Enumerable objects


        static public String DictionaryToString(Dictionary<String,int> dict)
        {
            bool first = true;
            String output = "";
            foreach (KeyValuePair<string, int> pair in dict)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    output += ", ";
                }

                output += pair.Value.ToString();
            }

            return output;

        }
        
        static public String StringListToString(List<String> list)
        {
            bool first = true;
            String output = "";
            foreach (String str in list)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    output += ", ";
                }

                output += str;
            }

            return output;

        }

        static public String intListToString(List<int> list)
        {
            bool first = true;
            String output = "";
            foreach (int i in list)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    output += ", ";
                }

                output += i.ToString();
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
