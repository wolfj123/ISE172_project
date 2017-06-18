using FluentScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls.Primitives;

namespace WpfApplication1.AMA
{
    public partial class ScheduleForm : Form
    {
        MainWindow mainWindow;

         public ScheduleForm(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            int minutes = (int) numericMinutes.Value;
            var registry = new Registry();

            IJob myjob = new MyJob(this.mainWindow);
            if(radioButton1.Checked)
                registry.Schedule(myjob).ToRunOnceIn(minutes).Minutes();
            if(radioButton2.Checked)
                registry.Schedule(myjob).ToRunOnceIn(minutes).Hours();
            if (radioButton3.Checked)
                registry.Schedule(myjob).ToRunOnceIn(minutes).Seconds();

            JobManager.Initialize(registry);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //minute
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //hours
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //seconds
        }
    }


    public class MyJob : IJob
    {
        MainWindow mainWindow;

        public MyJob(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        public void Execute()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => {
                mainWindow.enableAMA();
            }));
            System.Windows.MessageBox.Show("AMA initiated as scheduled!");      
        }
    }
}
