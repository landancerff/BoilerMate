using BoilerMate.Models;
using BoilerMate.Services;
using BoilerMate.ViewModels;
using Plugin.FilePicker;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoilerMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

   
    public partial class ExportPage : ContentPage
    {
        ExportViewModel viewModel;
        public ExportPage()
        {    
            InitializeComponent();

            BindingContext = viewModel = new ExportViewModel();           
        }

        private void SelectFile(object sender, EventArgs e)
        {
            // option to oen xlxs file or create pdf version
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadExportCommand.Execute(null);
        }
    }
}