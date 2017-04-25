using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketClient.PL_BL;
using MarketClient.GUI;

namespace WpfApplication1
{
    public partial class buySellReq : Form
    {
        public String buySell;
        public InputCheck checker;
        public userWarner warner;

        public buySellReq(String s)
        {
            InitializeComponent();
            this.buySell = s;
        }

        private void reqWin_Load(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //commidity
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            //amount
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //price
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int com = Convert.ToInt32(textBox1.Text);
            int amount = Convert.ToInt32(textBox2.Text);
            int price = Convert.ToInt32(textBox3.Text);
            Object[] tocheck = { com, amount, price };
            bool[] o = checker.intCheck(tocheck);
            bool y = warner.notTrue(o);
            if !(y)
                MessageBox.Show(this, "your input is illegal");
            else { }
            MessageBox.Show(this, "your request has been sent");
            if (this.buySell == "buy")
            {

                BuyRequest buyR = new BuyRequest(com, amount, price);
            }
            if (this.buySell == "sell")
            {
                SellRequest sellR = new SellRequest(com, amount, price);
            }
        }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
