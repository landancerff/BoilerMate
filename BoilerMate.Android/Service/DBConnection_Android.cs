using BoilerMate.Droid.Service;
using BoilerMate.Interfaces;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DBConnection_Android))]
namespace BoilerMate.Droid.Service
{
    class DBConnection_Android : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {
            var dbName = "JobDatabase.db";
            var path =  Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            //var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            return new SQLiteConnection(path);
        }
    }
}