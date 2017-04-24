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
    public partial class reqWin : Form
    {
        public reqWin()
        {
            InitializeComponent();
        }

        private void reqWin_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, textBox1.Text);
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
