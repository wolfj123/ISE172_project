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
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Current Status"; // Default file name
            dialog.DefaultExt = ".pdf"; // Default file extension
            dialog.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dialog.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document
                string res = dialog.FileName;

                var doc1 = new Document();
                PdfWriter.GetInstance(doc1, new FileStream(res, FileMode.Create));

                QueryUserRequest req1 = new QueryUserRequest();
                IMarketResponse resp1 = InterperatorPB.sendRequest(req1);
                QueryAllBuySellRequest req2 = new QueryAllBuySellRequest();
                List<MQReqWrapper> resp2 = InterperatorPB.sendAllUserRequest();
                
                doc1.Open();
                doc1.Add(new iTextSharp.text.Paragraph("CURRENT USER STATUS:"));
                doc1.Add(new iTextSharp.text.Paragraph("\n"));
                doc1.Add(new iTextSharp.text.Paragraph(resp1.ToString()));
                doc1.Add(new iTextSharp.text.Paragraph("\n"));
                foreach (var element in resp2)
                {
                    doc1.Add(new iTextSharp.text.Paragraph(element.ToString()));
                }

                    // doc1.Add(new iTextSharp.text.Paragraph(InterperatorPB.sendAllUserRequest().ToString()));

                doc1.Close();

                myLogger.Info("User Export status report");
            }
        }
    }
}
