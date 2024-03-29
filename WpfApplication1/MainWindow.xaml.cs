﻿using System;
using System.Windows;
using MarketClient.BL;
using log4net;
using System.Net;
using System.Threading;
using System.Collections;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        private bool runningAMA;
        private ICommunicator comm;
        private DefaultAdvancedAMA ama;
        private DefaultAdvancedAMA userAma;

        public MainWindow()
        {
            myLogger.Info("\nMainWindow initialized");
            InitializeComponent();
            ama = new DefaultMomentumAMA();
            userAma = new DefaultAdvancedAMA();
            runningAMA = false;
        }


        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened BuyForm");
            //buy
            forms.buyForm userInput = new forms.buyForm();
            userInput.Show();


        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened SellForm");

            forms.sellForm userInput = new forms.sellForm();

            userInput.Show();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened CancelForm");

            forms.cancelForm userInput = new forms.cancelForm();

            userInput.Show();
        }

        private void requestQueryButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened idStatusForm");

            forms.idStatusForm userInput = new forms.idStatusForm();

            userInput.Show();
        }

        private void marketQueryButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened ComStatForm");

            forms.comStatForm userInput = new forms.comStatForm();
            userInput.Show();
        }

        private void userQueryButton_Click(object sender, RoutedEventArgs e)
        {


            forms.userStatForm userInput = new forms.userStatForm();
            userInput.Show();
            myLogger.Info("User clicked QUERY USER");
        }

        private void amaButton_Click(object sender, RoutedEventArgs e)
        {
            runningAMA = !runningAMA;       //toggle runningAMA
            myLogger.Info("User set Default AMA enabled to " + runningAMA);
            ama.enable(runningAMA);         //toggle ama

            if (!runningAMA)
            {
                MessageBox.Show("The GUI will be locked 10 seconds before you can continue working.");
                System.Threading.Thread.Sleep(10000);
            }

            enableControls(!runningAMA);     //enable/disable mainwindow
            amaButton.IsEnabled = true;

            if (runningAMA)     //update text
                amaButton.Content = "Stop default AMA";
            else amaButton.Content = "Run default AMA";
        }

        private void amaString_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User viewed Default AMA rules list");
            MessageBox.Show(this, ama.ToString());
        }

        private void userAMAbutton_Click(object sender, RoutedEventArgs e)
        {
            runningAMA = !runningAMA;       //toggle runningAMA
            myLogger.Info("User set User AMA enabled to " + runningAMA);
            userAma.enable(runningAMA);         //toggle ama

            enableControls(!runningAMA);     //enable/disable mainwindow
            userAMAbutton.IsEnabled = true;

            if (!runningAMA)
            {
                MessageBox.Show("The GUI will be locked 10 seconds before you can continue working.");
                System.Threading.Thread.Sleep(10000);
            }

            if (runningAMA)     //update text
                userAMAbutton.Content = "Stop user AMA";
            else userAMAbutton.Content = "Run user AMA";
        }

        private void userAMAString_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User viewed User AMA rules list");
            MessageBox.Show(this, userAma.ToString());
        }

        private void clearLogicButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User cleared AMA logic");
            userAma.clearLogic();
            MessageBox.Show(this, "User AMA has been cleared of all rules!");
        }

        private void addLogicButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened SellForm");

            AMA.AddLogicForm addLogicForm = new AMA.AddLogicForm(userAma, comm);
            addLogicForm.userAma = this.userAma;
            addLogicForm.comm = this.comm;

            addLogicForm.Show();
        }

        private void ConnectionTestButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User clicked ConnectionTest");

            string url = "http://ise172.ise.bgu.ac.il";


            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                try
                {
                    // Creates an HttpWebRequest for the specified URL. 
                    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    // Sends the HttpWebRequest and waits for a response.
                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
                        MessageBox.Show("\r\nResponse Status Code is: OK" + "\n" + "StatusDescription is: " +
                                             myHttpWebResponse.StatusDescription);
                    // Releases the resources of the response.
                    myHttpWebResponse.Close();

                }
                catch (WebException webE)
                {
                    MessageBox.Show("\r\nWebException Raised. The following error occured : " + webE.Status);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("\nThe following Exception was raised : " + ex.Message);
                }

            }).Start();
        }

        private void enableControls(bool mode)
        {
            myLogger.Info("MainWindow controls set to " + mode);

            buyButton.IsEnabled = mode;
            sellButton.IsEnabled = mode;
            cancelButton.IsEnabled = mode;

            requestQueryButton.IsEnabled = mode;
            marketQueryButton.IsEnabled = mode;
            userQueryButton.IsEnabled = mode;

            amaButton.IsEnabled = mode;
            userAMAbutton.IsEnabled = mode;
            addLogicButton.IsEnabled = mode;
            clearLogicButton.IsEnabled = mode;

            //set enable mode to all forms
            IEnumerator en = System.Windows.Forms.Application.OpenForms.GetEnumerator();
            while (en.MoveNext()) {
                System.Windows.Forms.Form form = (System.Windows.Forms.Form)en.Current;
                form.Enabled = mode;
            }
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User clicked historyButton");
            forms.historyForm userInput = new forms.historyForm();
            userInput.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User clicked statButton");
            forms.statForm userInput = new forms.statForm();
            userInput.Show();
        }

        private void schedule_click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User clicked scheduleButton");
            AMA.ScheduleForm scheduleForm = new AMA.ScheduleForm(this);
            scheduleForm.Show();
        }

        public void enableAMA()
        {
            this.amaButton_Click(null, null);
        }
    }
}
