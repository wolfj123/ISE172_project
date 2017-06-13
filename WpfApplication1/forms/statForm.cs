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
        private SQL_DAL_implementation hadas= new SQL_DAL_implementation();
        public statForm()
        {
            InitializeComponent();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            float[] comsAvPrice= new float[10];
            for (int i = 0; i<comsAvPrice.Length; i++)
            {
                comsAvPrice[i] = hadas.PriceAverage(i);
            }

        }
    }
}
