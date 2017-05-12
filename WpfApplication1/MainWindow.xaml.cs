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

namespace WpfApplication1
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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
        }


        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            //buy
            forms.buyForm userInput = new forms.buyForm();
            userInput.Show();
        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            forms.sellForm userInput = new forms.sellForm();
            //buySellReq userInput = new buySellReq("sell");
            userInput.Show();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            forms.cancelForm userInput = new forms.cancelForm();
            //intReq userInput = new intReq("cancel");
            userInput.Show();
        }

        private void rquestQueryButton_Click(object sender, RoutedEventArgs e)
        {
            forms.idStatusForm userInput = new forms.idStatusForm();
            //intReq userInput = new intReq("buySellQ");
            userInput.Show();
        }

        private void marketQueryButton_Click(object sender, RoutedEventArgs e)
        {
            forms.comStatForm userInput = new forms.comStatForm();
            userInput.Show();
        }

        private void userQueryButton_Click(object sender, RoutedEventArgs e)
        {
            QueryUserRequest req = new QueryUserRequest();
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());
        }

        private void amaButton_Click(object sender, RoutedEventArgs e)
        {
            runningAMA = !runningAMA;       //toggle runningAMA
            ama.enable(runningAMA);         //toggle ama

            enableControls(!runningAMA);     //enable/disable mainwindow
            amaButton.IsEnabled = true;

            if (runningAMA)     //update text
                amaButton.Content = "Stop default AMA";
            else amaButton.Content = "Run default AMA";
        }

        private void amaString_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, ama.ToString());
        }

        private void userAMAbutton_Click(object sender, RoutedEventArgs e)
        {
            runningAMA = !runningAMA;       //toggle runningAMA
            userAma.enable(runningAMA);         //toggle ama

            enableControls(!runningAMA);     //enable/disable mainwindow
            userAMAbutton.IsEnabled = true;

            if (runningAMA)     //update text
                userAMAbutton.Content = "Stop user AMA";
            else userAMAbutton.Content = "Run user AMA";

        }

        private void userAMAString_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, userAma.ToString());
        }

        private void clearLogicButton_Click(object sender, RoutedEventArgs e)
        {
            userAma.clearLogic();
            MessageBox.Show(this, "User AMA has been cleared of all rules!");
        }

        private void addLogicButton_Click(object sender, RoutedEventArgs e)
        {

        }



        private void enableControls(bool mode)
        {




        }
    }
}
