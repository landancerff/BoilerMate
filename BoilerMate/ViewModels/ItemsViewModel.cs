using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using BoilerMate.Models;
using BoilerMate.Views;
using System.Collections.Generic;
using BoilerMate.Services;

namespace BoilerMate.ViewModels
{
    
    public class ItemsViewModel : BaseViewModel
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();

        public ObservableCollection<JobReport> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Previous Quotes";
            Items = new ObservableCollection<JobReport>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, JobReport>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as JobReport;
                Items.Add(newItem);
                await _context.SaveJobAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
          
            try
            {
                Items.Clear();
                List<string> jobs = new List<string>();

                Tools toolContext = new Tools();
                var items =  _context.GetAllJobsAsync();

                var outImg = new Image();

                foreach (var item in items)
                {
                    item.Picture = (Image)toolContext.RetriveImageFromLocation(item.PictureLocation, item.PictureName, outImg);
                    Items.Add(item);
                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}