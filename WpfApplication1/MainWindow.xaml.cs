using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MarketClient.BL;
using MarketClient.PL_BL;
using log4net;

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
        private DefaultAMA ama;
        private UserAMA userAma;

        public MainWindow()
        {
            InitializeComponent();
            comm = new Communicator();
            ama = new DefaultAMA(comm);
            userAma = new UserAMA();
            runningAMA = false;


            myLogger.Info("\nMainWindow initialized");
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
            //buySellReq userInput = new buySellReq("sell");
            userInput.Show();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened CancelForm");

            forms.cancelForm userInput = new forms.cancelForm();
            //intReq userInput = new intReq("cancel");
            userInput.Show();
        }

        private void requestQueryButton_Click(object sender, RoutedEventArgs e)
        {
            myLogger.Info("User opened idStatusForm");

            forms.idStatusForm userInput = new forms.idStatusForm();
            //intReq userInput = new intReq("buySellQ");
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
            QueryUserRequest req = new QueryUserRequest();
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());

            //myLogger.Info("User opened SellForm");
        }

        private void amaButton_Click(object sender, RoutedEventArgs e)
        {
            runningAMA = !runningAMA;       //toggle runningAMA
            myLogger.Info("User set Default AMA enabled to " + runningAMA);
            ama.enable(runningAMA);         //toggle ama

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
            AMA.AddLogicForm addLogicForm = new AMA.AddLogicForm();
            addLogicForm.userAma = this.userAma;
        }



        private void enableControls(bool mode)
        {
            myLogger.Info("MainWindow controls set to " + mode);

            marketActionsgroup.IsEnabled = false;



        }
    }
}
