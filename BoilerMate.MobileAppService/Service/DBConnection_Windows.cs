using BoilerMate.Interfaces;
using BoilerMate.MobileAppService.Service;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DBConnection_Windows))]
namespace BoilerMate.MobileAppService.Service
{
    public class DBConnection_Windows : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {
            var dbName = "JobDatabase.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            //var plat = new SQLite.Net.Platform.Win32.SQLitePlatformWin32();
            return new SQLiteConnection(path);
        }
    }
}
