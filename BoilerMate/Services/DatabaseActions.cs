using BoilerMate.Interfaces;
using BoilerMate.Models;
using BoilerMate.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseActions))]


namespace BoilerMate.Services
{
    public class DatabaseActions
    {       
   
        public class DatabaseManager
        {
            private SQLiteConnection database;
            public  DatabaseManager()
            {
                database = DependencyService.Get<IDBInterface>().CreateConnection();                
            }
            SQLiteStore context = new SQLiteStore();

            public List<JobReport> GetAllJobsAsync()
            {
                
                if (context.TableExists("PreviousJobs"))
                {
                    return database.Query<JobReport>("Select * From PreviousJobs");
                }
                else
                {
                    if (context.CreateTableAsync("PreviousJobs"))
                    {
                        return database.Query<JobReport>("Select * From PreviousJobs");
                    }
                    return null;
                }               
            }

            public List<JobReport> GetSpecificJobAsync(int id)
            {

                if (context.TableExists("PreviousJobs"))
                {
                    return database.Query<JobReport>($"Select * From PreviousJobs where id={id}");
                }
                else
                {
                    if (context.CreateTableAsync("PreviousJobs"))
                    {
                        return database.Query<JobReport>("Select * From PreviousJobs");
                    }
                    return null;
                }
            }

            public async Task<int> SaveJobAsync(JobReport job)
            {
              
              // context.DeleteTable();    

                if (context.TableExists("PreviousJobs")){
                    return database.Insert(job);
                }
                else
                {
                    context.CreateTableAsync("PreviousJobs");
                    if (context.TableExists("PreviousJobs")){
                        return database.Insert(job);
                    }
                    return default;
                }

               
            }

            public async Task<int> SaveSettingsAsync(RequirementSpec job)
            {
                // context.DeleteTable();    

                if (context.RequirementTableExists("RequirementSpec"))
                {                  
                    return database.Update(job);
                }
                else
                {
                    context.CreateTableRequirementAsync("RequirementSpec");
                    if (context.RequirementTableExists("RequirementSpec"))
                    {
                        return database.Insert(job);
                    }
                    return default;
                }

            }


            public List<ExportModel> GetAllExportsAsync()
            {
                //context.DeleteTable();
                if (context.ExportTableExists("ExportModel"))
                {
                    return database.Query<ExportModel>("Select * From ExportModel");
                }
                else
                {
                    if (context.CreateExportTableAsync("ExportModel"))
                    {
                        return database.Query<ExportModel>("Select * From ExportModel");
                    }
                    return null;
                }
            }

            public List<RequirementSpec> GetAllRequirementValues()
            {
                if (context.RequirementTableExists("RequirementSpec"))
                {
                    return database.Query<RequirementSpec>("Select * From RequirementSpec");
                }
                else
                {
                    if (context.CreateTableRequirementAsync("RequirementSpec"))
                    {
                        return database.Query<RequirementSpec>("Select * From RequirementSpec");
                    }
                    return null;
                }
            }



            public async Task<int> SaveExportAsync(ExportModel job)
            {

                //context.DeleteTable();    Clear data of table, use if new fields are added.

                if (context.ExportTableExists("ExportModel"))
                {
                    return database.Insert(job);
                }
                else
                {
                    context.CreateExportTableAsync("ExportModel");
                    if (context.ExportTableExists("ExportModel"))
                    {
                        return database.Insert(job);
                    }
                    return default;
                }

            }
        }
    }
}
