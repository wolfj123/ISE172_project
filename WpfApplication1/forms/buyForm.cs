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
    public partial class buyForm : Form
    {
        public buyForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //commodity
            int[] commoList = formsMethod.listGet(null);
            for (int i = 0; i < commoList.Length - 1; i++) {
                comboBox1.Items.Add(commoList[i]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //amount
            int[] amountList = formsMethod.listGet(null);
            for (int i = 0; i < amountList.Length - 1; i++)
            {
                comboBox1.Items.Add(amountList[i]);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //price
            int[] priceList = formsMethod.listGet(null);
            for (int i = 0; i < priceList.Length - 1; i++)
            {
                comboBox1.Items.Add(priceList[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //send
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
    }
}
