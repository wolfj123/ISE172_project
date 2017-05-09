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

namespace WpfApplication1.forms
{
    public partial class sellForm : Form
    {
        public sellForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //send
            int com = (int)numericUpDown1.Value;
            int amount = (int)numericUpDown2.Value;
            int price = (int)numericUpDown3.Value;
            SellRequest req = new SellRequest(com, amount, price);
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //commidity
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //amount
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //price
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
    }
}
