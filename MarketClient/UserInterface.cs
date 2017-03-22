using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;


namespace MarketClient
{
    class Program
    {
        static void Main()
        {
            String url = "http://ise172.ise.bgu.ac.il";

        }

        
    }





    class Interperator
    {
        private Credentials credentials;
        private Poster poster;

        public Interperator(Credentials credentials)
        {
            this.credentials = credentials;
            this.poster = new Poster(credentials);
        }


        public void Interperate(int cmd)
        {
            
            switch (cmd)
            {
                case 1 : //Buy

                    String[] names = new String[] {"price", "commodity", "amount"};
                    int[] inputs = new int[3];
                    AskInput(names, inputs);


                    poster.SendBuyRequest(inputs[0], inputs[1], inputs[2]);
                    break;



                default:
                    Display.Unknown();
                    break;
            }



        }


        private int[] AskInput(String[] names, int[] inputs)
        {

        }

        private bool CheckType(String input, InputSlot inputSlot)
        {

        }

    }




    public class Credentials
    {
        public String url;
        public String username;
        public String token;

        public Credentials(String url, String username, String token)
        {
            this.url = url;
            this.username = username;
            this.token = token;
        }
    }



    public class InputSlot
    {
        public String name;
        public int data;

        public InputSlot(String name, int data)
        {


        }
    }


    public class Display
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
            Console.WriteLine("Unknown Command. Write 'help' if you need assistance.");
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
