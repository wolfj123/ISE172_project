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
            int minutesS = (int)numericMinutes.Value;
            int minutesP = (int)numericMinutes.Value + (int)numericUpDown1.Value;
            var registry = new Registry();

            IJob myjob = new MyJob(this.mainWindow);
            if (radioButton1.Checked)
            {
                registry.Schedule(myjob).ToRunOnceIn(minutesS).Minutes();
                if (radioButton5.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Minutes();
                if (radioButton6.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Hours();
                if (radioButton4.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Seconds();
            }
            if (radioButton2.Checked)
            {
                registry.Schedule(myjob).ToRunOnceIn(minutesS).Hours();
                if (radioButton5.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Minutes();
                if (radioButton6.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Hours();
                if (radioButton4.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Seconds();
            }
            if (radioButton3.Checked)
            {
                registry.Schedule(myjob).ToRunOnceIn(minutesS).Seconds();
                if (radioButton5.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Minutes();
                if (radioButton6.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Hours();
                if (radioButton4.Checked)
                    registry.Schedule(myjob).ToRunOnceIn(minutesP).Seconds();
            }

            JobManager.Initialize(registry);
        }
        
        private void durtion()
        {
            int minutes = (int)numericMinutes.Value + (int)numericUpDown1.Value;
            var registry = new Registry();

            IJob myjob = new MyJob(this.mainWindow);
            if (radioButton5.Checked)
                registry.Schedule(myjob).ToRunOnceIn(minutes).Minutes();
            if (radioButton6.Checked)
                registry.Schedule(myjob).ToRunOnceIn(minutes).Hours();
            if (radioButton4.Checked)
                registry.Schedule(myjob).ToRunOnceIn(minutes).Seconds();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label run in:
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //minute to run
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //hours to run
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //seconds to run
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //label choose duration:
        }

        private void numericMinutes_ValueChanged(object sender, EventArgs e)
        {
            //numeric to run in
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //second duration
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //minutes duration
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //hours duration
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ////numeric duration
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
            //panel 1
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //panel 2 
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
            //System.Windows.MessageBox.Show("AMA initiated as scheduled!");      
        }
    }
}
