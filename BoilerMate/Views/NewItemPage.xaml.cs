using Android.App;
using BoilerMate.Models;
using BoilerMate.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]
namespace BoilerMate.Views
{

    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();

        public JobReport Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new JobReport
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
                PictureLocation = "",
                PictureName = ""

            };
            
            BindingContext = this;

           CameraButton.Clicked += CameraButton_Clicked;
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photoname = $"JP{Item.Id}{DateTime.Now.Millisecond}.jpg";
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Directory = $"Job Pictures {Item.HouseNumber}{Item.AddressLine1}",
                Name = photoname,
                SaveToAlbum = true
            }) ;

            Item.PictureLocation = photo.AlbumPath;
            Item.PictureName = photoname;

            if (photo != null)
            {
                this.PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
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
            catch(Exception ex)
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