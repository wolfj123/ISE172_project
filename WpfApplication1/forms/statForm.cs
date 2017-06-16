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

namespace WpfApplication1.forms
{
    public partial class statForm : Form
    {
        private String[] graphsList;
        private SQL_DAL_implementation hadas= new SQL_DAL_implementation();

        public statForm()
        {
            this.graphsList = new String[2];
            graphsList[0] = "Average price";
            graphsList[1] = "Highest sell";
            InitializeComponent();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<10; i++)
            {
                chart1.Series[graphsList[0]].Points.AddXY(i, hadas.PriceAverage(i));
                chart1.Series[graphsList[1]].Points.AddXY(i, hadas.highestSell(i));
            }


            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Average price");
        }
    }
}
