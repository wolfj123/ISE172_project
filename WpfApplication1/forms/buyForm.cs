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
using log4net;


namespace WpfApplication1.forms
{
    public partial class buyForm : Form
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public buyForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //send
            
            int commodity = (int)numericUpDown1.Value;
            int amount = (int)numericUpDown2.Value;
            int price = (int)numericUpDown3.Value;
            BuyRequest req = new BuyRequest(commodity, amount, price);
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());

            myLogger.Info("User clicked BUY: {commodity: " + commodity + ", price: " + price + ", amount: " + amount + "}");

        }


        private void label1_Click(object sender, EventArgs e)
        {
            //commodity label
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //amount label
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //price label
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //total
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //com
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //amount
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //price
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //totalshow
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //refresh
            textBox1.Text = "";
            int sum = (int)numericUpDown2.Value *
                (int)numericUpDown3.Value;
            String sumS = "" + sum;
            textBox1.Text = sumS;
        }
    }
}
