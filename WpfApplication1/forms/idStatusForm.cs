using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApplication1.forms
{
    public partial class idStatusForm : Form
    {
        public idStatusForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //choose request ID
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ID list
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //show status
            MessageBox.Show(this, "there isnt");
        }
    }
}
