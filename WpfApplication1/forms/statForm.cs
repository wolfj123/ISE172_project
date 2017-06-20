using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIprim.Utils;
using MarketClient.DataEntries;
using log4net;

namespace WpfApplication1.forms
{
    public partial class statForm : Form
    {
        private String[] graphsList;
        private HistoryDalImplementation historyAcc= new HistoryDalImplementation();
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public statForm()
        {
            this.graphsList = new String[3];
            graphsList[0] = "Average price";
            graphsList[1] = "Times reached highest price";
            graphsList[2] = "Times reached lowest price";
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //chart
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            
            for (int i = 0; i<10; i++)
            {
                if (checkBox1.Checked && historyAcc.PriceAverage(DateTime.Now.AddHours(-24), DateTime.Now, i)!=-1)
                    chart1.Series[graphsList[0]].Points.AddXY(i, historyAcc.PriceAverage(DateTime.Now.AddHours(-24), DateTime.Now, i));
                if (checkBox2.Checked && historyAcc.numOfHighest(DateTime.Now.AddHours(-24), DateTime.Now, i)!=-1)
                    chart1.Series[graphsList[1]].Points.AddXY(i, historyAcc.numOfHighest(DateTime.Now.AddHours(-24), DateTime.Now, i));
                if (checkBox3.Checked && historyAcc.numOfLowest(DateTime.Now.AddHours(-24), DateTime.Now, i)!=-1)
                    chart1.Series[graphsList[2]].Points.AddXY(i, historyAcc.numOfLowest(DateTime.Now.AddHours(-24), DateTime.Now, i));
            }
            myLogger.Info("User generate graph");
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            //head line
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //avPrice
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //highest price
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //lowest price
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //explain:
        }

    }
}
