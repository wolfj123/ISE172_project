using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.Utils
{
    static public class Shell
    {

        //isNumeric function for String and String[]
        static public bool isNumeric(String s)
        {
            if (s.Length == 0)
                return false;
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
        
        //combine the values in the dictionary into string
        static public string DictionaryToString(Dictionary<String,int> dict)
        {
            bool first = true;
            string output = "";
            foreach (KeyValuePair<string, int> pair in dict)
            {
                if (first) //designated to avoid "," at the beginning   
                {
                    first = false;
                }
                else
                {
                    output += ", ";
                }

                output +="{" + pair.Key + ": " +pair.Value.ToString() + "}";
                
            }
            
            return output;

        }

        //combine the values in the list into string
        static public string StringListToString(List<String> list)
        {
            bool first = true;
            string output = "";
            foreach (String str in list)
            {
                if (first) //designated to avoid "," at the beginning
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

        //combine the values in the int list into string
        static public string intListToString(List<int> list)
        {
            bool first = true;
            String output = "";
            foreach (int i in list)
            {
                if (first) //designated to avoid "," at the beginning
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


        static public string listToString<T1>(List<T1> list)
        {
            string output = "";
            foreach(T1 o in list)
            {
                output += o.ToString() + " \n";
            }
            return output;
        }
    }
}
