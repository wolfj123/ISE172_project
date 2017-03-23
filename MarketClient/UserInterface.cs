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
            //Default values:
            String url = "http://ise172.ise.bgu.ac.il";
            String username = "user36";
            String key = "tmp"; //How do you write this ?!?!
            String token = SimpleCtyptoLibrary.CreateToken(username, key);
          
            
            /*
            * String key = -----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQCuGdcd1NEIrVWC / bjTAWQUfjhC6yJMQF / udGKvO7Yp + Dlnxbhk
1gNQrmD9ICjyEOGrKaubCJnrI0Zcjvfml3n9FhJUJeD6XrE6dSY0znUoNc8juBae
e1dy / 29plyXuQOft1fL0MsckfcSWZzJ / 64Cpdh515oGeUqQjiZdI6Y / vmQIDAQAB
AoGARiHipgG0suogKERMz7MfvaGayFov1seX3VbE6hIDr6Rue38KaJRNgZK9PzpV
RC3Iukpu9mTgm / f5wA9XjWw3lzGOt0qt08dK / 63ESA6e1Bbe2 + S3zIqn1JM8SJ6J
ZGys1YCvezEadh00Ia16dZhixVrvtaHERsUHi5dzGP0EYoECQQDHWaJRYEo10lbz
57ajQvTp / oDHGJNjd5l9L1EAQO4 + VHc1fIpgYye9g / msPIX6bqpWaTSAMoR7phl5
TuVy9LxPAkEA35NfWoEDbSYw1yjezMwVm2EORYOd18EjGTRYQHSkQbXiyp2NMNKy
DHzSZao7iw38CwYVejo6VNYoyxkQJVUTlwJABjYawqJXbZniL7NWk3uwmeHeLVXs
sbq2Q5pH0dQ0GCkVlcsNnLc6M8N68gzot8be89ZPVnc8fYXNYWQ97fkGLQJAPUT9
1KeWcMsOh2hD5ovnP / WRG6u + Dep32 + hkZwWQHhHiXPRgRQj4kkOCxSmpt6nVcI / y
QtTCN42ZEE + GBTUTcQJBAMafJ6ike5spiGCkx2ZzHh9IUu9H9TJ4u5KNxJiP1BIS
rxv9gh / KJgqOXc / YV3RG1FuQdflRy3ZvQutoIrznyKA =
-----END RSA PRIVATE KEY---- - 

    */


            Credentials userInfo = new Credentials(url, username, token);
            Interperator interperator = new Interperator(userInfo);

            interperator.Run();

        }

        
    }


    public class Interperator
    {
        private Credentials userInfo;
        //private Poster poster;

        public Interperator(Credentials userInfo)
        {
            this.userInfo = userInfo;
            //this.poster = new Poster(userInfo);
        }


        public void Run()
        {
            while(true)
            {
                String cmd = Console.ReadLine();
                while(!isNumeric(cmd))
                {
                    Display.MustBeInt();
                    cmd = Console.ReadLine();
                }

                Interperate(Int32.Parse(cmd));

            }


        }

        public void Interperate(int cmd)
        {
            
            switch (cmd)
            {
                case 1 : //Buy

                    String[] slots = new String[] { "price", "commodity", "amount" };
                    InputSlot inputSlots = new InputSlot(slots);
                    int[] inputs = AskInput(inputSlots);
                    
                    //int response = poster.SendBuyRequest(inputs[0], inputs[1], inputs[2]);

                    //Display.Write(response);
                    break;



                default:
                    Display.Unknown();
                    break;
            }



        }


        private int[] AskInput(InputSlot inputSlots)
        {
            for(int i = 0; i<inputSlots.names.Length; i= i+1)
            {
                Display.Write(inputSlots.names[i] + "?");
                String currentInput = Console.ReadLine();

                //If the user submitted non-integer string
                while (!isNumeric(currentInput))
                {
                    Display.MustBeInt();
                    currentInput = Console.ReadLine();
                }

            }

            return inputSlots.data;
        }
        
        static public bool isNumeric(String s)
        {
            int i = 0;
            return int.TryParse(s, out i);
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
        public String[] names;
        public int[] data;

        public InputSlot(String[] names)
        {
            this.names = names;
            this.data = new int[names.Length];
        }
    }


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
