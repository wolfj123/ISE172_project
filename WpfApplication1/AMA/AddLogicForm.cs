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
using log4net;

namespace WpfApplication1.AMA
{
    public partial class AddLogicForm : Form
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public DefaultAdvancedAMA userAma;
        public ICommunicator comm;

        public AddLogicForm(DefaultAdvancedAMA userAma, ICommunicator comm)
        {
            this.userAma = userAma;
            this.comm = comm;
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int commodity = (int)commodityNumeric.Value;
            int price = (int)priceNumeric.Value;

            bool isBuyLogic = buyRadioButton.Checked;

            AlgoProcess newLogic = null;
            if (isBuyLogic)
                newLogic = new AlgoCompareBuyProcess(userAma, comm, commodity, price);
            else
                newLogic = new AlgoCompareSellProcess(userAma, comm, commodity, price);


            bool succes = false;
            try
            {
                myLogger.Info("User attempted to add Logic: " + newLogic);
                userAma.add(newLogic);
                succes = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(succes)
                MessageBox.Show(this, "New Rule added!");
        }

        private void buyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (buyRadioButton.Checked)
            {
                bidAsk.Text = "ASK";
                belowAbove.Text = "below";
            }
        }

        private void SellRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SellRadioButton.Checked)
            {
                bidAsk.Text = "BID";
                belowAbove.Text = "above";
            }
        }


    }
}
