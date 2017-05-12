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
    public partial class cancelForm : Form
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public cancelForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //choose request
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
            int id = (int)numericUpDown1.Value;
            CancelRequest req = new CancelRequest(id);
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());

            myLogger.Info("User clicked CANCEL: {ID: " + id + "}");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
