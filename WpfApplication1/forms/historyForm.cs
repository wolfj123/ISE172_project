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
using log4net;

namespace WpfApplication1.forms
{
    public partial class historyForm : Form
    {
        DateTime startDate;
        DateTime endDate;

        public historyForm()
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
                textBox1.Text = "";
                DateTime startDate = Convert.ToDateTime(monthCalendar1.SelectionStart);
                DateTime endDate = Convert.ToDateTime(monthCalendar1.SelectionEnd);
                textBox1.Text = startDate + "  + " + endDate;
                String[] historyLines = HistoryView.historyByDate(startDate, endDate);
                textBox1.Lines = historyLines;
                historyError(historyLines);
            }
            if (byDayRB.Checked)
            {
                textBox1.Text = "";
                int dayNum =(int)numericUpDown1.Value;
                String[] historyLines = HistoryView.historyBydays(dayNum);
                textBox1.Lines = historyLines;
                historyError(historyLines);
            }
        }

        private void historyError(String[] str)
        {
            if(str == null)
            {
                textBox1.Text = "The history file is empty";
            }
            else if(str.Length == 0)
            {
                textBox1.Text = "There isnt history from the selected dates, :( " +
                    "you can choose a larger range and try again ";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteHistoryButton_Click(object sender, EventArgs e)
        {
            HistoryView.deleteHistory();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
       {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cleanTextButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
