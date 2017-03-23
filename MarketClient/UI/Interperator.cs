using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.BL;
using MarketClient.DAL;

namespace MarketClient.UI
{
    public class Interperator
    {
        private LoginInfo loginInfo;
        private Poster poster;

        public Interperator(LoginInfo loginInfo)
        {
            this.loginInfo = loginInfo;
            this.poster = new Poster(loginInfo);
        }


        public void Run()
        {
            while (true)
            {
                String cmd = Console.ReadLine();
                while (!isNumeric(cmd))
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
                case 1: //Buy

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
            for (int i = 0; i < inputSlots.names.Length; i = i + 1)
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


}
