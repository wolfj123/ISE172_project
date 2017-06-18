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
            registry.Schedule(myjob).ToRunOnceIn(minutes).Seconds();

            JobManager.Initialize(registry);
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
