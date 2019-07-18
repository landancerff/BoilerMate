using BoilerMate.Models;
using BoilerMate.Services;
using BoilerMate.ViewModels;
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
    public partial class Settings : ContentPage
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
       
        public RequirementSpec Item { get; set; }
       
        public SettingsViewModel viewModel;

        public Settings(SettingsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            //Item = new RequirementSpec { };            
        }
        public Settings()
        {
            Item = new RequirementSpec { };
            InitializeComponent();
            BindingContext = viewModel = new SettingsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Item.Count == 0)
                viewModel.LoadSettingsCommand.Execute(null);
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                var response = await _context.SaveSettingsAsync(Item);

                if (response != default)
                {
                    await DisplayAlert("Success", "Pricing Updated", "OK");
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
    
    }
}