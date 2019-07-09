using BoilerMate.Interfaces;
using BoilerMate.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Tools))]
namespace BoilerMate.Services
{
    public class Tools : IFileService
    {
     
        public void SavePicture(string name, System.IO.Stream data, string location = "temp")
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Jobs", location);
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (data)
                {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);
            }
        }

        public  Image RetriveImageFromLocation(string location, string imageName, Image newImg)
        {
            var memoryStream = new MemoryStream();
            
            using (var source = System.IO.File.OpenRead(location))
            {
                 source.CopyToAsync(memoryStream);
            }
           // newImg.FindByName(imageName);
            newImg.Source = ImageSource.FromStream(() => memoryStream);

            return newImg;
        }

        //public List<string> RetrieveExports ()
        //{
        //    List<string> output = new List<string>();
         
        //    using(var reader = new StreamReader(location))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            if (line.EndsWith(".xlsx"))
        //            {
        //                output.Add(line);
        //            }
        //        }
        //    }
        //    return output;         
        //}
    }
}
