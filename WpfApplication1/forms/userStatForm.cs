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
    public partial class userStatForm : Form
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public userStatForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryUserRequest req = new QueryUserRequest();
            IMarketResponse res = InterperatorPB.sendRequest(req);
            textBox1.Text = res.ToString().Replace("\n", "\r\n");
            myLogger.Info("User clicked UPDATE STATUS");
        }
    }
}
