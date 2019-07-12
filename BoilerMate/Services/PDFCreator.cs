using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using Java.IO;
using Android.Media;
using Xamarin.Forms;
using System.Reflection;
using Syncfusion.Pdf.Tables;
using Color = Syncfusion.Drawing.Color;

namespace BoilerMate.Services
{
  public class PDFCreator
    {
        public MemoryStream testc( )
        {


            var text = "Blaze Boilers & Fires";


            PdfDocument doc = new PdfDocument();


            //Adds a page.
            PdfPage page = doc.Pages.Add();

            //create a new PDF string format
            PdfStringFormat drawFormat = new PdfStringFormat();
            drawFormat.WordWrap = PdfWordWrapType.Word;
            drawFormat.Alignment = PdfTextAlignment.Justify;
            drawFormat.LineAlignment = PdfVerticalAlignment.Top;
            PdfTemplate header = AddHeader(doc, text, "Header and Footer Demo");
            page.Graphics.DrawPdfTemplate(header, new PointF());

            PdfFont headFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16f);
            PdfBrush brush = PdfBrushes.Red;

            RectangleF headerBounds = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

           //PdfPageTemplateElement header = new PdfPageTemplateElement(headerBounds);
            //PdfTextElement elementHead = new PdfTextElement(text, headFont, brush);

            //Set the string format
            //elementHead.StringFormat = drawFormat;
            
            //Draw the text element
           // PdfLayoutResult resultHead = elementHead.Draw(page, headerBounds);
           // doc.Template.Top = header;

           
            

            //bounds
            RectangleF bounds = new RectangleF(new PointF(20, 20), new SizeF(page.Graphics.ClientSize.Width - 30, page.Graphics.ClientSize.Height - 20));

            //Create a new text elememt
            PdfTextElement element = new PdfTextElement("01293400400", headFont, brush);

            //Set the string format
            element.StringFormat = drawFormat;

            //Draw the text element
            PdfLayoutResult result = element.Draw(page, bounds);

            // Draw the string one after another.
            result = element.Draw(result.Page, new RectangleF(result.Bounds.X, result.Bounds.Bottom + 10, result.Bounds.Width, result.Bounds.Height));

            // Creates a PdfLightTable.
            PdfLightTable pdfLightTable = new PdfLightTable();

            //Add colums to light table
            pdfLightTable.Columns.Add(new PdfColumn("Item"));
            pdfLightTable.Columns.Add(new PdfColumn("Description"));
            pdfLightTable.Columns.Add(new PdfColumn("Cost"));

            //Add row        
            pdfLightTable.Rows.Add(new string[] { "abc", "21", "Male" });


            PdfLightTable totalTable = new PdfLightTable();

            totalTable.Columns.Add(new PdfColumn("Total"));
            totalTable.Rows.Add(new string[] { "£34" });


            //Includes the style to display the header of the light table.
            pdfLightTable.Style.ShowHeader = true;

            //Draws PdfLightTable and returns the rendered bounds.
            result = pdfLightTable.Draw(page, new PointF(result.Bounds.Left, result.Bounds.Bottom + 20));

            //draw string with returned bounds from table
            result = element.Draw(result.Page, result.Bounds.X, result.Bounds.Bottom + 10);

            //draw string with returned bounds from table
            element.Draw(result.Page, result.Bounds.X, result.Bounds.Bottom + 10);
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);

            return stream;
        }


        private static PdfTemplate AddHeader(PdfDocument doc, string title, string description)
        {
            SizeF rect = new SizeF(doc.Pages[0].GetClientSize().Width, 50);

            //Create page template
            PdfTemplate header = new PdfTemplate(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            float doubleHeight = font.Height * 2;
            Color activeColor = Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(110f, 35f);
            //Locating the logo on the right corner of the drawing surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);


            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            //Set formatting for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            pen = new PdfPen(Color.DarkBlue, 0.7f);
            header.Graphics.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, 03, header.Width + 3, 03);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            header.Graphics.DrawLine(pen, 0, header.Height, header.Width, header.Height);

            return header;
        }

    }
}
