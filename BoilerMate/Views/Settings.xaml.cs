using BoilerMate.Models;
using BoilerMate.Services;
using BoilerMate.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoilerMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {

        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
        public RequirementSpec SettingItem { get; set; }
        public ObservableCollection<RequirementSpec> specCol = new ObservableCollection<RequirementSpec>();
        public SettingsViewModel viewModel;

        public Settings()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    // base.OnAppearing();
        //    ObservableCollection<RequirementSpec> jobs = new ObservableCollection<RequirementSpec>();

        //    var pageVm = this;

        //    if (pageVm != null)
        //    {
        //        var items = _context.GetAllRequirementValues();              


        //        SettingItem = new RequirementSpec
        //        {
        //            ID = items[0].ID,
        //            CondensafeValue = items[0].CondensafeValue,
        //            CondPumpValue = items[0].CondPumpValue,
        //            ThirtySiCompValue = items[0].ThirtySiCompValue,
        //            Junior30iValue = items[0].Junior30iValue,
        //            FlashingValue = items[0].FlashingValue

        //        };

        //        jobs.Add(SettingItem);

        //        PriceSettingsView.ItemsSource =  jobs;
        //    }
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            specCol = new ObservableCollection<RequirementSpec>(_context.GetAllRequirementValues());

            PriceSettingsView.ItemsSource = specCol;
            SettingItem = specCol[0];
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {

                MessagingCenter.Send<Settings, RequirementSpec>(this, "AddItem", SettingItem);

                var response = await _context.SaveSettingsAsync(SettingItem);

                if (response != default)
                {
                    await DisplayAlert("Success", "Pricing Updated", "OK");
                    // await Navigation.PopModalAsync();
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

    }
}