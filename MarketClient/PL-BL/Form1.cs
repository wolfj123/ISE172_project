using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketClient.DataEntries;

namespace MarketClient.PL_BL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    

        private void byDateButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void showHistory_Click(object sender, EventArgs e)
        {
            

        }

        private void byDayRB_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            monthCalendar1.Enabled = false;
        }

        private void byDateRB_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            monthCalendar1.Enabled = true;
        }

        private void showHistButton_Click(object sender, EventArgs e)
        {
            if (byDateRB.Checked)
            {
                String inputDate = monthCalendar1.SelectionRange.Start.ToString();
            }
            if (byDayRB.Checked)
            {
                int dayNum =(int)numericUpDown1.Value;
                String[] historyLines = HistoryView.historyBydays(dayNum); 

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
