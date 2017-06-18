using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketClient.PL_BL;
using log4net;
using GUIprim.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using MarketClient.BL;

namespace WpfApplication1.forms
{
    public partial class userStatForm : Form
    {
        private static ILog myLogger = LogManager.GetLogger("fileLogger");

        public userStatForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryUserRequest req = new QueryUserRequest();
            IMarketResponse res = InterperatorPB.sendRequest(req);
            textBox1.Text = res.ToString().Replace("\n", "\r\n");
            myLogger.Info("User clicked UPDATE STATUS");
        }

        private void userStatForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document
                string res = dlg.FileName;

                var doc1 = new Document();
                PdfWriter.GetInstance(doc1, new FileStream(res, FileMode.Create));

                QueryUserRequest req1 = new QueryUserRequest();
                IMarketResponse resp1 = InterperatorPB.sendRequest(req1);
                //QueryAllBuySellRequest req2 = new QueryAllBuySellRequest();
                List<MQReqWrapper> resp2 = InterperatorPB.sendAllUserRequest();
              
                doc1.Open();
                doc1.Add(new iTextSharp.text.Paragraph(resp1.ToString()));
                doc1.Close();
            }
        }
    }
}
