using BoilerMate.Interfaces;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace BoilerMate.Services
{
    public class DatabaseService : IDBInterface
    {     
        public SQLiteConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
