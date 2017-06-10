using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MarketClient.Utils
{
    class GeneratePDF
    {
        public GeneratePDF() { }
        
        public void ceate(String fileName, String substance)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(substance));
            doc.Close();
        }
    }
}
