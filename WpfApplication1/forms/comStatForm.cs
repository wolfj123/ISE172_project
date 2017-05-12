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
    public partial class comStatForm : Form
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

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
            int commodity = (int)numericUpDown1.Value;
            QueryMarketRequest req = new QueryMarketRequest(commodity);
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());

            myLogger.Info("User clicked QUERY COMMODITY: {commodity: " + commodity + "}");
        }
    }
}
