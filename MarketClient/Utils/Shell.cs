using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.Utils
{
    static public class Shell
    {

        //isNumeric function for String and Strin[]
        static public bool isNumeric(String s)
        {
            if (s.Length == 0)
                throw new Exception("String s cannot be empty!");
            int i = 0;
            return int.TryParse(s, out i);
        }


        static public bool isNumeric(String[] s)
        {
            if (s == null || s.Length == 0)
                throw new NullReferenceException();
            return isNumeric(s, 0);

        }


        static public bool isNumeric(String[] s, int start)
        {
            if (start >= s.Length)
                throw new IndexOutOfRangeException();

            for (int i=start; i<s.Length; i=i+1)
            {
                if (!isNumeric(s[i]))
                    return false;
            }

            return true;
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

    }
}
