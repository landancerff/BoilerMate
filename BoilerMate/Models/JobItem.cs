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

        public int ThirtySiCompQTY { get; set; }    
        public int ThirtySiCompTotal { get; set; }

        public int Junior30iQTY { get; set; }
              public int Junior30iTotal { get; set; }

        public int FlashingQTY { get; set; }
        public int FlashingTotal { get; set; }

        public int HFueQTY { get; set; }     
        public int HFueTotal { get; set; }

        public int VFlueQTY { get; set; }       
        public int VFlueTotal { get; set; }

        public int OneMExtQTY { get; set; }      
        public int OneMExtTotal { get; set; }

        public int Deg45QTY { get; set; }        
        public int Deg45Total { get; set; }

        public int Deg90QTY { get; set; }       
        public int Deg90Total { get; set; }

        public int PlumeKitQTY { get; set; }       
        public int PlumeKitTotal { get; set; }

        public int GuardQTY { get; set; }      
        public int GuardTotal { get; set; }

        public int ShockArQTY { get; set; }      
        public int ShockArTotal { get; set; }

        public int ScaleRedQty { get; set; }       
        public int ScaleRedTotal { get; set; }

        public int RFPStatQTY { get; set; }        
        public int RFPStatTotal { get; set; }

        public int FLoopQTY { get; set; }       
        public int FLoopTotal { get; set; }

        public int X800QTY { get; set; }      
        public int X800Total { get; set; }

        public int InhibitorQTY { get; set; }       
        public int InhibitorTotal { get; set; }

        public int MB3QTY { get; set; }       
        public int MB3Total { get; set; }

        public int TwinTechQTY { get; set; }      
        public int TwinTechTotal { get; set; }

        public int CondensafeQTY { get; set; }       
        public int CondensafeTotal { get; set; }

        public int SoakAwayQTY { get; set; }       
        public int SoakAwayTotal { get; set; }

        public int CondPumpQTY { get; set; }       
        public int CondPumpTotal { get; set; }

        public int Ri12QTY { get; set; }
        public int Ri12Total { get; set; }

        public int Ri15QTY { get; set; }      
        public int Ri15Total { get; set; }


        public int Ri18QTY { get; set; }        
        public int Ri18Total { get; set; }

        public int Ri24QTY { get; set; }      
        public int Ri24Total { get; set; }

        public int i18QTY { get; set; }
        public int i18Total { get; set; }

        public int i27QTY { get; set; }       
        public int i27Total { get; set; }

        public int PumpQTY { get; set; }   
        public int PumpTotal { get; set; }

        public int UnionsQTY { get; set; }      
        public int UnionsTotal { get; set; }

        public int ControlPK3pQTY { get; set; }     
        public int ControlPK3pTotal { get; set; }

        public int ControlPK2pQTY { get; set; }       
        public int ControlPK2pTotal { get; set; }

        public int ImmersionQTY { get; set; }        
        public int ImmersionTotal { get; set; }

        public int Cyl900x450QTY { get; set; }      
        public int Cyl900x450Total { get; set; }

        public int Cyl900x400QTY { get; set; }  
        public int Cyl900x400Total { get; set; }

        public int Cyl1050x450QTY { get; set; }    
        public int Cyl1050x450Total { get; set; }

        public int Cyl1200x450QTY { get; set; }      
        public int Cyl1200x450Total { get; set; }

        public int JunctionBoxQTY { get; set; }      
        public int JunctionBoxTotal { get; set; }

        public int SpurQTY { get; set; }     
        public int SpurTotal { get; set; }

        public int Ins15mmQTY { get; set; }      
        public int Ins15mmTotal { get; set; }

        public int Ins22mmQTY { get; set; }  
        public int Ins22mmTotal { get; set; }

        public int SpeedFitQTY { get; set; }    
        public int SpeedFitTotal { get; set; }

        public int LShieldQTY { get; set; }
        public int LShieldTotal { get; set; }

        public int Pipe15mmx3mQTY { get; set; }       
        public int Pipe15mmx3mTotal { get; set; }

        public int Pipe22mmx3mQTY { get; set; }   
        public int Pipe22mmx3mTotal { get; set; }

        public int TRVsQTY { get; set; }
        public int TRVsTotal { get; set; }

        public int MiscQTY { get; set; }
        public int MiscTotal { get; set; }

        public int RadiatorQTY { get; set; } 
        public int RadiatorTotal { get; set; }

        public int DaysQTY { get; set; }  
        public int DaysTotal { get; set; }

        public int SubTotal { get; set; }

        public int VATRate { get; set; }    
        public int VATTotal { get; set; }


        public int TotalCost { get; set; }
        public int QuotePriceTotal { get; set; }
        public int GrossProfitTotal { get; set; }

        #endregion

        #region Media

        public string PictureLocation { get; set; }
        public string PictureName { get; set; }

        [Ignore]
        public Image Picture { get; set; }

        #endregion

    }
}