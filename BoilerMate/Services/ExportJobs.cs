using Android.Content;
using BoilerMate.Models;
using BoilerMate.ViewModels;
using Java.IO;
using Plugin.FilePicker;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BoilerMate.Services
{
    public class ExportJobs
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
        public async Task<bool> generateFileAsync(JobReport item)
        {          

            using (ExcelEngine excel = new ExcelEngine())
            {
                excel.Excel.DefaultVersion = ExcelVersion.Excel2016;

                IWorkbook workbook = excel.Excel.Workbooks.Create();

                IWorksheet worksheet = excel.Excel.Worksheets[0];

                worksheet.Range["A1"].Text = item.Id.ToString();
                worksheet.Range["B1"].Text = item.Description;

                //// add the rest of the fields once the model has been built correctly

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);

                workbook.Close();

               await SaveAndView($"Export_{item.HouseNumber}_{item.AddressLine1}.xlsx", "application/msexcel", stream);

                return true;
            }
        }
               

        //Method to save document as a file in Android and view the saved document
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
            Java.IO.File myDir = new Java.IO.File(root + "/Exports");
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
             

                System.Globalization.CultureInfo enUK = new System.Globalization.CultureInfo("en-GB");

                DateTime now = DateTime.Now;

                var outDate = Convert.ToDateTime(now, enUK);

                ExportModel exp = new ExportModel{
                    CreatedDate = outDate,
                    FileName = fileName,
                    FilePath = path.ToString()
                };

               await _context.SaveExportAsync(exp);
                
            }
        }
    }
}
