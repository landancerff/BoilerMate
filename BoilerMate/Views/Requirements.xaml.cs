using BoilerMate.Models;
using BoilerMate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoilerMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Requirements : ContentPage
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
        public JobReport Item { get; set; }
        public RequirementSpec Spec { get; set; }

        public Requirements(JobReport item)
        {
            InitializeComponent();

            Item = item;
           
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                RequirementCalc reqCalc = new RequirementCalc();
                //generate the total costs etc before updating the DB
                var total = reqCalc.CalculateRequirements(Item);
                Item.TotalCost = total;
                var response = await _context.SaveJobAsync(Item);

                if (response != default)

                {
                    await DisplayAlert("Success", "Job saved", "OK");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex}", "OK");
            }
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            var cancel = await DisplayAlert("Continue?", "Current progress will be lost", "OK", "Cancel");
            if (cancel)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                //Do nothing
            }

        }

       async void TotalGenerator(object sender, EventArgs e)
        {
            RequirementCalc calc = new RequirementCalc();
            BindingContext = this;
            Item.TotalCost = calc.CalculateRequirements(Item);
           // TotalJobCost.Text = calc.CalculateRequirements(Item);
        }

            void OnPickerChanged30Si(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ThirtySiCompQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

     
        void OnPickerChangedJunior30i(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Junior30iQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedFlashing(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.FlashingQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedHFlue(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.HFueQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedVFlue(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.VFlueQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged1MExt(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.OneMExtQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged45Degree(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Deg45QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged90Degree(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Deg90QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedPlumeKit(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.PlumeKitQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedGuard(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.GuardQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedShockAr(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ShockArQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedScaleRed(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ScaleRedQty = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedREFPStat(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.RFPStatQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedFLoop(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.FLoopQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedX800(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.X800QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedInhibitor(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.InhibitorQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedMB3(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.MB3QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedTwinTech(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.TwinTechQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCondensafe(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.CondensafeQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedSoakAway(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.SoakAwayQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCondPump(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.CondPumpQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged12Ri(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Ri12QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged15Ri(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Ri15QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged18Ri(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Ri18QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged24Ri(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Ri24QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged18i(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.i18QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged27i(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.i27QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedPump(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.PumpQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedUnions(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.UnionsQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged3PControlPk(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ControlPK3pQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged2PControlPk(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ControlPK2pQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedImmersion(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ImmersionQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCylinder900x450(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Cyl900x450QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCylinder900x400(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Cyl900x400QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCylinder1050x450(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Cyl1050x450QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCylinder1200x450(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Cyl1200x450QTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedJunctionBox(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.JunctionBoxQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedSpur(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.SpurQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged15mmIns(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Ins15mmQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged22mmIns(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Ins22mmQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedSpeedFit(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.SpeedFitQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedLShield(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.LShieldQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged15mmx3m(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Pipe15mmx3mQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChanged22mmx3m(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Pipe22mmx3mQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedTVRs(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.TRVsQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedMisc(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.MiscQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedDayRate(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.DaysQTY = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedVat(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.VATRate = selectedIndex + 1; //picker.Items[selectedIndex];
            }
        }

    }



}