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

            public List<RequirementSpec> GetAllPricesAsync()
            {
               
                if (context.TableExists("RequirementSpec"))
                {
                    return database.Query<RequirementSpec>("Select * From RequirementSpec where ID = 1");
                }
                else
                {
                    if (context.CreateTableAsync("RequirementSpec"))
                    {
                        return database.Query<RequirementSpec>("Select * From RequirementSpec where ID = 1");
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
                //context.DeleteTable("ExportModel");
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
                var specCol = new ObservableCollection<RequirementSpec>(FirstTimeSettings());
                if (context.RequirementTableExists("RequirementSpec"))
                {
                   
                    if (specCol.Count != 0)
                    {
                        return database.Query<RequirementSpec>("Select * From RequirementSpec where id = 1");
                    }
                    else
                    {
                        RequirementSpec job = new RequirementSpec();
                        database.Insert(job);
                        return database.Query<RequirementSpec>("Select * From RequirementSpec where id = 1");
                    }                   
                }
                else
                {
                    if (context.CreateTableRequirementAsync("RequirementSpec"))
                    {
                        if (specCol.Count != 0)
                        {
                            return database.Query<RequirementSpec>("Select * From RequirementSpec where id = 1");
                        }
                        else
                        {
                            RequirementSpec job = new RequirementSpec();
                            database.Insert(job);
                            return database.Query<RequirementSpec>("Select * From RequirementSpec where id = 1");
                        }
                    }
                    return null;
                }
            }


            public List<RequirementSpec>  FirstTimeSettings()
            {
                return database.Query<RequirementSpec>("select * from requirementspec where id = 1");
            }


            public async Task<int> SaveExportAsync(ExportModel job)
            {           

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
