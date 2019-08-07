using BoilerMate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoilerMate.Services
{
    public class RequirementCalc
    {

        public int CalculateRequirements(JobReport job)
        {
            DatabaseActions.DatabaseManager dbContext = new DatabaseActions.DatabaseManager();
            var reqPrice = dbContext.GetAllPricesAsync();

            foreach (var price in reqPrice)
            {
                List<KeyValuePair<string, int>> totalArray = new List<KeyValuePair<string, int>>()
            {
               new KeyValuePair<string, int>("ThirtySiCompTotal",  job.ThirtySiCompTotal = job.ThirtySiCompQTY * price.ThirtySiCompValue),
                new KeyValuePair<string, int>("CondensafeTotal", job.CondensafeTotal = job.CondensafeQTY * price.CondensafeValue),
                new KeyValuePair<string, int>("CondPumpTotal", job.CondPumpTotal = job.CondPumpQTY * price.CondPumpValue),
                new KeyValuePair<string, int>("ControlPK2pTotal", job.ControlPK2pTotal = job.ControlPK2pQTY * price.ControlPK2pValue),
                new KeyValuePair<string, int>("ControlPK3pTotal", job.ControlPK3pTotal = job.ControlPK3pQTY * price.ControlPK3pValue),
                new KeyValuePair<string, int>("Cyl1050x450Total", job.Cyl1050x450Total = job.Cyl1050x450QTY * price.Cyl1050x450Value),
                new KeyValuePair<string, int>("Cyl1200x450Total", job.Cyl1200x450Total = job.Cyl1200x450QTY * price.Cyl1200x450Value),
                new KeyValuePair<string, int>("Cyl900x400Total", job.Cyl900x400Total = job.Cyl900x400QTY * price.Cyl900x400Value),
                new KeyValuePair<string, int>("Cyl900x450Total", job.Cyl900x450Total = job.Cyl900x450QTY * price.Cyl900x450Value),
                new KeyValuePair<string, int>("DaysTotal", job.DaysTotal = job.DaysQTY * price.DaysValue),
                new KeyValuePair<string, int>("Deg45Total", job.Deg45Total = job.Deg45QTY * price.Deg45Value),
                new KeyValuePair<string, int>("Deg90Total", job.Deg90Total = job.Deg90QTY * price.Deg90Value),
                new KeyValuePair<string, int>("FlashingTotal", job.FlashingTotal = job.FlashingQTY * price.FlashingValue),
                new KeyValuePair<string, int>("FLoopTotal", job.FLoopTotal = job.FLoopQTY * price.FLoopValue),
                new KeyValuePair<string, int>("GuardTotal", job.GuardTotal = job.GuardQTY * price.GuardtValue),
                new KeyValuePair<string, int>("HFueTotal", job.HFueTotal = job.HFueQTY * price.HFueValue),
                new KeyValuePair<string, int>("i18Total", job.i18Total = job.i18QTY * price.i18Value),
                new KeyValuePair<string, int>("i27Total", job.i27Total = job.i27QTY * price.i27Value),
                new KeyValuePair<string, int>("ImmersionTotal", job.ImmersionTotal = job.ImmersionQTY * price.ImmersionValue),
                new KeyValuePair<string, int>("InhibitorTotal", job.InhibitorTotal = job.InhibitorQTY * price.InhibitorValue),
                new KeyValuePair<string, int>("Ins15mmTotal", job.Ins15mmTotal = job.Ins15mmQTY * price.Ins15mmValue),
                new KeyValuePair<string, int>("Ins22mmTotal", job.Ins22mmTotal = job.Ins22mmQTY * price.Ins22mmValue),
                new KeyValuePair<string, int>("JunctionBoxTotal", job.JunctionBoxTotal = job.JunctionBoxQTY * price.JunctionBoxValue),
                new KeyValuePair<string, int>("Junior30iTotal", job.Junior30iTotal = job.Junior30iQTY * price.Junior30iValue),
                new KeyValuePair<string, int>("LShieldTotal", job.LShieldTotal = job.LShieldQTY * price.LShieldValue),
                new KeyValuePair<string, int>("MB3Total", job.MB3Total = job.MB3QTY * price.MB3Value),
                new KeyValuePair<string, int>("MiscTotal", job.MiscTotal = job.MiscQTY * price.MiscValue),
                new KeyValuePair<string, int>("OneMExtTotal", job.OneMExtTotal = job.OneMExtQTY * price.OneMExtValue),
                new KeyValuePair<string, int>("Pipe15mmx3mTotal", job.Pipe15mmx3mTotal = job.Pipe15mmx3mQTY * price.Pipe15mmx3mValue),
                new KeyValuePair<string, int>("Pipe22mmx3mTotal", job.Pipe22mmx3mTotal = job.Pipe22mmx3mQTY * price.Pipe22mmx3mValue),
                new KeyValuePair<string, int>("PlumeKitTotal", job.PlumeKitTotal = job.PlumeKitQTY * price.PlumeKitValue),
                new KeyValuePair<string, int>("PumpTotal", job.PumpTotal = job.PumpQTY * price.PumpValue),
                new KeyValuePair<string, int>("RadiatorTotal", job.RadiatorTotal = job.RadiatorQTY * price.RadiatorValue),
                new KeyValuePair<string, int>("RFPStatTotal", job.RFPStatTotal = job.RFPStatQTY * price.RFPStatValue),
                new KeyValuePair<string, int>("Ri12Total", job.Ri12Total = job.Ri12QTY * price.Ri12Value),
                new KeyValuePair<string, int>("Ri15Total", job.Ri15Total = job.Ri15QTY * price.Ri15Value),
                new KeyValuePair<string, int>("Ri18Total", job.Ri18Total = job.Ri18QTY * price.Ri18Value),
                new KeyValuePair<string, int>("Ri24Total", job.Ri24Total = job.Ri24QTY * price.Ri24Value),
                new KeyValuePair<string, int>("ScaleRedTotal", job.ScaleRedTotal = job.ScaleRedQty * price.ScaleRedValue),
                new KeyValuePair<string, int>("ShockArTotal", job.ShockArTotal = job.ShockArQTY * price.ShockArValue),
                new KeyValuePair<string, int>("SoakAwayTotal", job.SoakAwayTotal = job.SoakAwayQTY * price.SoakAwayValue),
                new KeyValuePair<string, int>("SpeedFitTotal", job.SpeedFitTotal = job.SpeedFitQTY * price.SpeedFitValue),
                new KeyValuePair<string, int>("SpurTotal", job.SpurTotal = job.SpurQTY * price.SpurValue),
                new KeyValuePair<string, int>("TRVsTotal", job.TRVsTotal = job.TRVsQTY * price.TRVsValue),
                new KeyValuePair<string, int>("TwinTechTotal", job.TwinTechTotal = job.TwinTechQTY * price.TwinTechValue),
                new KeyValuePair<string, int>("UnionsTotal", job.UnionsTotal = job.UnionsQTY * price.UnionsValue),
                new KeyValuePair<string, int>("VFlueTotal", job.VFlueTotal = job.VFlueQTY * price.VFlueValue),
                new KeyValuePair<string, int>("X800Total", job.X800Total = job.X800QTY * price.X800Value)


            };
                job.TotalCost = GetTotal(totalArray);
            }
          
            return job.TotalCost;
        }

        public int GetTotal(List<KeyValuePair<string, int>> totalArray)
        {
            int total = 0;

            foreach (KeyValuePair<string, int> kvp in totalArray)
            {
                total += kvp.Value;
            }

            return total;
        }
    }

   
}
