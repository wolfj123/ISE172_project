﻿using System;
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

        public UserAMA userAma;
        public ICommunicator comm;

        public AddLogicForm(UserAMA userAma, ICommunicator comm)
        {
            this.userAma = userAma;
            this.comm = comm;
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
                newLogic = new BuyProcess(true, comm, commodity, price, amount, -1);
            else
                newLogic = new SellProcess(true, comm, commodity, price, amount, -1);

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
