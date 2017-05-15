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
    public partial class idStatusForm : Form
    {

        private static ILog myLogger = LogManager.GetLogger("fileLogger");
        public idStatusForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //choose request ID
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ID list
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show status
            int id = (int)numericUpDown1.Value;
            QueryBuySellRequest req = new QueryBuySellRequest(id);
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());

            myLogger.Info("User clicked QUERY REQUEST: {ID: " + id + "}");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
