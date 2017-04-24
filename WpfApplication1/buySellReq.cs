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

namespace WpfApplication1
{
    public partial class buySellReq : Form
    {
        public String buySell;

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
            MessageBox.Show(this, "your request has been sent");
            if (this.buySell == "buy")
            {

               BuyRequest buyR = new BuyRequest(com, amount, price);//NOT WORKING
            }
            if (this.buySell == "sell")
            {
               SellRequest sellR = new SellRequest(com, amount, price);
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
