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

        private void Next_Clicked(object sender, EventArgs e) =>  new NavigationPage(new Requirements(Item));



        void OnPickerChangedBoilerGasSupply(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.BoilerGasSupply = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedWalls(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.BoilerGasSupply = picker.Items[selectedIndex];
            }
        }

        void SetLoftPropertyValue (object sender, EventArgs args)
        {
            var checkBox = (CheckBox)sender;

            if (checkBox.IsChecked)
            {
                Item.LoftLadder = true;
            }
            else if (!checkBox.IsChecked)
            {
                Item.LoftLadder = false;
            }
        }

        void OnPickerChangedDown(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Down = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedUp(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Up = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedTowelRads(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.TowelRads = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedPipeSize(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.TowelRads = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedShower(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ExistingShower = picker.Items[selectedIndex];
            }
        }
        void OnPickerChangedValve(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Valve = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedCylinder(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Cylinder = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedPump(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.Pump = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedLocationControls(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.ControlsLocation = picker.Items[selectedIndex];
            }
        }

        void OnPickerChangedLocationPump(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Item.PumpLocation = picker.Items[selectedIndex];
            }
        }
    }
}