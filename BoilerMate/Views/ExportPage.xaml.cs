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
using System.Collections.Generic;
using System.Windows.Input;

namespace BoilerMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]   
    public partial class ExportPage : ContentPage
    {
       
        ExportViewModel viewModel;
        DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
        ExportModel model = new ExportModel();

        public ExportPage()
        {    
            InitializeComponent();            
           
            BindingContext = viewModel = new ExportViewModel();
        }

        private void SelectFile(object sender, SelectedItemChangedEventArgs args)
        {

             model = args.SelectedItem as ExportModel;
            if (model == null) return;
           
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var job = button.BindingContext as ExportModel;
            GeneratePDFAsync(job);
        }

        private async void GeneratePDFAsync(ExportModel item)
        {           
            var pdfID = item.JobID;  
            var job = _context.GetSpecificJobAsync(pdfID);

            MemoryStream stream = new MemoryStream();
            PdfDocument document = new PdfDocument();

            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);


            var pdfValues = $"{job[0].HouseNumber}, {job[0].AddressLine1}, {job[0].AddressLine2}, {job[0].Postcode}, \r\n {job[0].FirstName} {job[0].LastName}, \r\n {job[0].Description}, {job[0].MobilePhone}";
                 
            graphics.DrawString($"<b> Job Valuation Report <b>  \r\n " + pdfValues, font, PdfBrushes.Black, new PointF(0, 0));      
         



            document.Save(stream);

            document.Close(true); 
            
            await SaveAndView($"PDF_{item.FileName}_{item.ID}.pdf", "application / pdf", stream);

            await DisplayAlert("Notification", "PDF Export has been created.", "OK");
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