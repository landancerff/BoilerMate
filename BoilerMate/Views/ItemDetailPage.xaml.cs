using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.OS;
using BoilerMate.Models;
using BoilerMate.ViewModels;
using Rg.Plugins.Popup.Services;
using System.Linq;
using System.Windows.Input;
using BoilerMate.Services;
using Plugin.FilePicker;

namespace BoilerMate.Views
{

    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            ExportButton.Clicked += GenerateExportAsync;
            PhotoImageDisplay.Source = ImageSource.FromFile(viewModel.Item.PictureLocation);
        }
       
         void ZoomSelectedImageAsync(object sender, EventArgs args)
        {
            var img = viewModel.Item.PictureLocation;

            PopupNavigation.Instance.PushAsync(new ImagePreviewer(img));
        }         

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new JobReport
            {
                FirstName = "",
                LastName = "",
                MobilePhone = "",
                HomePhone = "",
                HouseNumber = 0,
                AddressLine1 = "",
                AddressLine2 = "",
                AddressLine3 = "",
                Postcode = "",
                Description = "",
                Text = "",
                Picture = new Image()
            };
            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private async void GenerateExportAsync(object sender, EventArgs e)
        {
            ExportJobs exp = new ExportJobs();
            var item = viewModel.Item;
           if( await exp.generateFileAsync(item))
                await DisplayAlert("Success", "Export complete.", "OK");
           
        }

        //private async void SelectFile(object sender, EventArgs e)
        //{
        //    var file = await CrossFilePicker.Current.PickFile();

        //    if (file != null)
        //    {
        //        FileName.Text = file.FileName;
        //    }

        //}

        //async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var item = args.SelectedItem as ExportModel;
        //    if (item == null)
        //        return;

        //    //await Navigation.PushAsync(new ExportedItemView(new ExportViewModel(item)));

        //    // Manually deselect item.
        //    ExportsListView.SelectedItem = null;
        //}
    }
}