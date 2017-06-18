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
        System.Windows.Controls.Button button;

        public ScheduleForm(System.Windows.Controls.Button button)
        {
            InitializeComponent();
            this.button = button;
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {

        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            int minutes = (int) numericMinutes.Value;
            var registry = new Registry();
            registry.Schedule<MyJob>().ToRunOnceIn(minutes).Seconds();
            JobManager.Initialize(registry);
        }
    }


    public class MyJob : IJob
    {
        System.Windows.Controls.Button button;

        public MyJob(System.Windows.Controls.Button button)
        {
            this.button = button;
        }
        public void Execute()
        {
            System.Windows.MessageBox.Show("asdas");
            //button.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));


        }
    }
}
