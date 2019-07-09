using BoilerMate.Interfaces;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace BoilerMate.Services
{
    public class DatabaseService : IDBInterface
    {
        //public DatabaseService()
        //{
        //}

        //public SQLiteConnection CreateConnection()
        //{
        //    var sqliteFilename = "JobDatabase.db";
        //    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
        //    var path = Path.Combine(documentsPath, sqliteFilename);
        //    var platform = DependencyService.Get<IPlatformHelper>().GetPlatform();
        //    var param = new SQLiteConnectionString(path, false);
        //    var connection = new SQLiteConnection(() => new SQLiteConnection(platform, param));
        //    return connection;
        //}
        public SQLiteConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
