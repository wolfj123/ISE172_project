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
    public partial class buyForm : Form
    {
        public buyForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] toAdd = formsMethod.listGet();
            for (int i = 0; i < toAdd.Length - 1; i++) {
                comboBox1.Items.Add(toAdd[i]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] toAdd = formsMethod.listGet();
            for (int i = 0; i < toAdd.Length - 1; i++)
            {
                comboBox1.Items.Add(toAdd[i]);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] toAdd = formsMethod.listGet();
            for (int i = 0; i < toAdd.Length - 1; i++)
            {
                comboBox1.Items.Add(toAdd[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
