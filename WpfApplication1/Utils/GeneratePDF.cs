using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUIprim.Utils
{
    class GeneratePDF
    {
        private MemoryStream ms;
        private Document doc;
   //     private PdfWriter writer;
        private FileStream fs;

        public GeneratePDF(String fileName)
        {
            ms = new MemoryStream();
            doc = new Document();
            fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
        }

        public void create(String substance)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            //FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            //Document doc = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(doc, fs);



            using (var fileStream = new FileStream(@"C:\Users\shira\Desktop\‏MyFile.pdf",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();
                doc.Add(new Paragraph(substance));
                doc.Close();

                writer.Close();
             
            }

            ms.Close();

            //Response.ContentType = "pdf/application";
            //Response.AddHeader("content-disposition", "attachment;filename=First_PDF_document.pdf");
            //Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        }
    }

}
