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
    public partial class comStatForm : Form
    {
        public comStatForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //choose com
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //com
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int com = (int)numericUpDown1.Value;
            QueryMarketRequest req = new QueryMarketRequest(com);
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());
        }
    }
}
