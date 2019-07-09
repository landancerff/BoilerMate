using SQLite;
using System;
using Xamarin.Forms;

namespace BoilerMate.Models
{
    [Table("PreviousJobs")]
    public class JobReport
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }
        public string PictureLocation { get; set; }
        public string PictureName { get; set; }

        [Ignore]
        public Image Picture { get; set; }



    }
}