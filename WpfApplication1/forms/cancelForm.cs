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
    public partial class cancelForm : Form
    {
        public cancelForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //choose request
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //id list
            int[] idList = formsMethod.listGet(null);
            for (int i = 0; i < idList.Length - 1; i++)
            {
                comboBox1.Items.Add(idList[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
        }
    }
}
