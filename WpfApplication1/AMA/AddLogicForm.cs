using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketClient.BL;

namespace WpfApplication1.AMA
{
    public partial class AddLogicForm : Form
    {
        public UserAMA userAma;
        public ICommunicator comm;

        public AddLogicForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int commodity = (int)commodityNumeric.Value;
            int amount = (int)amountNumeric.Value;
            int price = (int)priceNumeric.Value;

            bool isBuyLogic = buyRadioButton.Checked;

            LogicProcess newLogic = null;

            if (isBuyLogic)
                newLogic = new BuyProcess(true, null, commodity, price, amount, -1);
            else
                newLogic = new SellProcess(true, null, commodity, price, amount, -1);

            userAma.add(newLogic);

            MessageBox.Show(this, "New Rule added !");
        }
    }
}
