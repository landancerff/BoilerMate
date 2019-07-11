using BoilerMate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BoilerMate.Services;
using SQLite;
using Xamarin.Forms;
using BoilerMate.Interfaces;

namespace BoilerMate.Services
{
    public class SQLiteStore
    {
        SQLiteConnection connection = DependencyService.Get<IDBInterface>().CreateConnection();

        public bool TableExists(string table)
        {
            var exists = connection.Query<JobReport>($"SELECT name FROM sqlite_master WHERE type = 'table' AND name = '{table}';");
            if (exists.Count > 0){ return true; }
            return false;
        }
        public bool CreateTableAsync(string table)
        {
          var response =  connection.CreateTable<JobReport>();

            if(response == SQLite.CreateTableResult.Created)
            {
                return true;
            }

            return false;
        }



        public bool ExportTableExists(string table)
        {
            var exists = connection.Query<ExportModel>($"SELECT name FROM sqlite_master WHERE type = 'table' AND name = '{table}';");
            if (exists.Count > 0) { return true; }
            return false;
        }
        public  bool CreateExportTableAsync(string table)
        {
            var response =  connection.CreateTable<ExportModel>();
            var i = string.Empty;
            i = connection.GetTableInfo("ExportModel").ToString();
            if (i != null) //  SQLite.CreateTableResult.Created)
            {               
                return true;
            }
            return false;
        }


        


        public bool DeleteTable(string table)
        {
            connection.Query<JobReport>($"drop table {table}");

            return true;
        }
    }
}
