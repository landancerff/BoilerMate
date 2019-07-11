using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoilerMate.Models
{
   public class ExportModel
    {
        [PrimaryKey, AutoIncrement, SQLite.Column("ID")]
        public int ID { get; set; }
        [ForeignKey(typeof(JobReport))]
        public int JobID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
