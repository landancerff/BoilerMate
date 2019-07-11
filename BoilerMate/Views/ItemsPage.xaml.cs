using BoilerMate.Models;
using BoilerMate.Services;
using BoilerMate.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BoilerMate.Views
{

    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            //SQLiteStore context = new SQLiteStore();
            //context.DeleteTable("PreviousJobs");
            BindingContext = viewModel = new ItemsViewModel();
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as JobReport;
            if (item == null)
                return;
            
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
               
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}