using SQLite;
using System;
using Xamarin.Forms;

namespace BoilerMate.Models
{
    [Table("PreviousJobs")]
    public class JobReport
    {

         #region GeneralDetails

        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SurveyDateTime { get; set; }
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
        public string EmailAddress { get; set; }

        #endregion


        #region Existing Boiler Details

        public string Marketing { get; set; }        
        public string EnquiryDetails { get; set; }
        public string Boiler { get; set; }
        public string Flue { get; set; }
        public string Location { get; set; }
        public string BoilerGasSupply { get; set; }
        public string GasMeterLocation { get; set; }
        public string SCock { get; set; }
        public bool HoseTape { get; set; }
        public string Floors { get; set; }
        public string Walls { get; set; }
        public bool LoftLadder { get; set; }
        public string Down { get; set; }
        public string Up { get; set; }
        public string TowelRads { get; set; }
        public int PipeSizes { get; set; }
        public string ExistingShower { get; set; }
        public string Valve { get; set; }
        public string GRFP { get; set; }
        public string Pump { get; set; }
        public string Cylinder { get; set; }
        public string ControlsLocation { get; set; }
        public string PumpLocation { get; set; }

        #endregion

        #region Job Requirements



        #endregion


        #region Media

        public string PictureLocation { get; set; }
        public string PictureName { get; set; }

        [Ignore]
        public Image Picture { get; set; }

        #endregion

    }
}