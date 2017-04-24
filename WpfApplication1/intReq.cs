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
    public partial class intReq : Form
    {
        public String intReqT;

        public intReq(String s)
        {
            InitializeComponent();
            this.intReqT = s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            MessageBox.Show(this, "your request has been sent");
            if (intReqT == "cancel")
            {
                CancelRequest cancelR = new CancelRequest(id);
            }
            if (intReqT == "buySellQ")
            {
                QueryBuySellRequest buySellQ = new QueryBuySellRequest(id);
            }
            if (intReqT == "marketQ")
            {
                QueryMarketRequest buySellQ = new QueryMarketRequest(id);
            }
        }
    }
}
