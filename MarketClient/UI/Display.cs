using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.UI
{

    public static class Display
    {

        static public void Write(String s)
        {
            Console.WriteLine(s);
        }

        static public void Clear()
        {
            Console.Clear();
        }

        static public void Help()
        {

        }

        static public void Unknown()
        {
            Console.WriteLine("Unknown Command");
        }

        static public void MustBeInt()
        {
            Console.WriteLine("Input must be integer!");
        }

        static public void Welcome()
        {
            Write("Welcome to the Market Client");
        }

        static public void Username()
        {
            Write("Username?");
        }

        static public void Key()
        {
            Write("Key?");
        }


    }
}
