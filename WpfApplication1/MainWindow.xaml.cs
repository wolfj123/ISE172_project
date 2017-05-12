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
using MarketClient.PL_BL;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //buy
            forms.buyForm userInput = new forms.buyForm();
            userInput.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            forms.sellForm userInput = new forms.sellForm();
            //buySellReq userInput = new buySellReq("sell");
            userInput.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            forms.cancelForm userInput = new forms.cancelForm();
            //intReq userInput = new intReq("cancel");
            userInput.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            forms.idStatusForm userInput = new forms.idStatusForm();
            //intReq userInput = new intReq("buySellQ");
            userInput.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            forms.comStatForm userInput = new forms.comStatForm();
            userInput.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            QueryUserRequest req = new QueryUserRequest();
            IMarketResponse res = InterperatorPB.sendRequest(req);
            MessageBox.Show(this, res.ToString());
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            forms.historyForm userInput = new forms.historyForm();
            userInput.Show();
        }
    }
}
