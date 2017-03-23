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

        static public String ArrayToString(String[] arr)
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

        static public String ArrayToString(int[] arr)
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


    }
}
