using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.IO;

namespace BoilerMate.Services
{
  public class PDFCreator
    {
        public bool testc()
        {
            PdfDocument doc = new PdfDocument();
            //Adds page settings
            doc.PageSettings.Orientation = PdfPageOrientation.Landscape;
            doc.PageSettings.Margins.All = 50;
            //Adds a page to the document
            PdfPage page = doc.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            string fileName = "test.pdf";

            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list
            List<object> data = new List<object>();
            Object row1 = new { ID = "E01", Name = "Clay" };
            Object row2 = new { ID = "E02", Name = "Thomas" };
            Object row3 = new { ID = "E03", Name = "Andrew" };
            Object row4 = new { ID = "E04", Name = "Paul" };
            Object row5 = new { ID = "E05", Name = "Gray" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            data.Add(row4);
            data.Add(row5);
            //Add list to IEnumerable
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(10, 10));
            //Save the PDF document to stream.
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //Close the document.
            doc.Close(true);
            //Save the stream into pdf file
            //The operation in Save under Xamarin varies between Windows Phone, Android and iOS platforms. Please refer PDF/Xamarin section for respective code samples.
            string root = null;
            //Get the root path in android device.
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Create directory and file 
            Java.IO.File myDir = new Java.IO.File(root + "/Exports/PDFs");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);
            return true;
        }

    }
}
