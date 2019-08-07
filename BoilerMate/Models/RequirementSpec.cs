
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoilerMate.Models
{
  
    [Table("RequirementSpec")]
    public class RequirementSpec
    {
        [PrimaryKey, AutoIncrement, Unique, SQLite.Column("ID")]
        public int ID { get; set; }

        public int ThirtySiCompValue { get; set; }
         
        public int Junior30iValue { get; set; }
        public int FlashingValue { get; set; }
        public int HFueValue { get; set; }
        public int VFlueValue { get; set; }
        public int OneMExtValue { get; set; }
        public int Deg45Value { get; set; }
        public int Deg90Value { get; set; }
        public int PlumeKitValue { get; set; }
        public int GuardtValue { get; set; }
        public int ShockArValue { get; set; }
        public int ScaleRedValue { get; set; }
        public int RFPStatValue { get; set; }
        public int FLoopValue { get; set; }
        public int X800Value { get; set; }
        public int InhibitorValue { get; set; }
        public int MB3Value { get; set; }
        public int TwinTechValue { get; set; }
        public int CondensafeValue { get; set; }
        public int SoakAwayValue { get; set; }
        public int CondPumpValue { get; set; }
        public int Ri12Value { get; set; }
        public int Ri15Value { get; set; }
        public int Ri18Value { get; set; }
        public int Ri24Value { get; set; }
        public int i18Value { get; set; }
        public int i27Value { get; set; }
        public int PumpValue { get; set; }
        public int UnionsValue { get; set; }
        public int ControlPK3pValue { get; set; }
        public int ControlPK2pValue { get; set; }
        public int ImmersionValue { get; set; }
        public int Cyl900x450Value { get; set; }
        public int Cyl900x400Value { get; set; }
        public int Cyl1050x450Value { get; set; }
        public int Cyl1200x450Value { get; set; }
        public int JunctionBoxValue { get; set; }
        public int SpurValue { get; set; }
        public int Ins15mmValue { get; set; }
        public int Ins22mmValue { get; set; }
        public int SpeedFitValue { get; set; }
        public int LShieldValue { get; set; }
        public int Pipe15mmx3mValue { get; set; }
        public int Pipe22mmx3mValue { get; set; }
        public int TRVsValue { get; set; }
        public int MiscValue { get; set; }
        public int RadiatorValue { get; set; }
        public int DaysValue { get; set; }
        public int VATValue { get; set; }

    }
}
