using BoilerMate.Models;
using BoilerMate.Services;
using BoilerMate.ViewModels;
using Plugin.FilePicker;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Android.Media;
using Java.IO;
using Android.Content;

namespace BoilerMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]   
    public partial class ExportPage : ContentPage
    {
        ItemDetailViewModel jobModel;
        ExportViewModel viewModel;

        public ExportPage()
        {    
            InitializeComponent();
            
            BindingContext = viewModel = new ExportViewModel();
        }

        private void SelectFile(object sender, EventArgs e)
        {
            // option to oen xlxs file or create pdf version
        }

        private async void GeneratePDFAsync(object sender, EventArgs e)
        {

            var pdfContent = jobModel.Item;  //needs to be selected Item's content.

            PdfDocument document = new PdfDocument();


            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;        
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);           
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));      
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            document.Close(true);           
           // await SaveAndView($"PDF_{item.HouseNumber}_{item.AddressLine1}.pdf", "application / pdf", stream);
        }

        public async Task SaveAndView(string fileName, String contentType, MemoryStream stream)
        {
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

            //Remove if the file exists
            if (file.Exists()) file.Delete();

            //Write the stream into the file
            FileOutputStream outs = new FileOutputStream(file);
            outs.Write(stream.ToArray());

            outs.Flush();
            outs.Close();

            //Invoke the created file for viewing
            if (file.Exists())
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);

                intent.AddFlags(ActivityFlags.NewTask);
                intent.SetDataAndType(path, mimeType);

                ///// add 'SAVE to DB' 


                //System.Globalization.CultureInfo enUK = new System.Globalization.CultureInfo("en-GB");

                //DateTime now = DateTime.Now;

                //var outDate = Convert.ToDateTime(now, enUK);

                //ExportModel exp = new ExportModel
                //{
                //    CreatedDate = outDate,
                //    FileName = fileName,
                //    FilePath = path.ToString()
                //};

               // await _context.SaveExportAsync(exp);

            }
        }







        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadExportCommand.Execute(null);
        }
    }
}