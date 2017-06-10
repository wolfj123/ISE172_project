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
        private PdfWriter writer;
        private FileStream fs;

        public GeneratePDF(String fileName) {
            ms = new MemoryStream();
            doc = new Document();
            fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            writer = PdfWriter.GetInstance(doc, fs);
        }
        
        public void create(String substance)
        {
            //FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            //Document doc = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(substance));
            doc.Close();
            ms.Close();
            //Response.ContentType = "pdf/application";
            //Response.AddHeader("content-disposition", "attachment;filename=First_PDF_document.pdf");
            //Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        }
    }
}
