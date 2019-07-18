using BoilerMate.Models;
using BoilerMate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BoilerMate.Views;

namespace BoilerMate.ViewModels
{
   
   public partial class SettingsViewModel : BaseViewModel
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
        public ObservableCollection<RequirementSpec> Item { get; set; }
        public Command LoadSettingsCommand { get; set; }
        public ExportModel Export { get; set; }

        public RequirementSpec Spec { get; set; }


        public SettingsViewModel()
        {
            Title = "Settings";
            Item = new ObservableCollection<RequirementSpec>();
            IsBusy = false;
            LoadSettingsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<Settings, RequirementSpec>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as RequirementSpec;
                Item.Add(newItem);
                await _context.SaveSettingsAsync(newItem);
            });
        }
        async Task ExecuteLoadItemsCommand()
        {
            ObservableCollection<RequirementSpec> jobs = new ObservableCollection<RequirementSpec>();
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Item.Clear();
               
                
                var items = _context.GetAllRequirementValues();

                //var outImg = new Image();

                foreach (var item in items)
                {
                    jobs.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Item = jobs;
                OnPropertyChanged(nameof(Item));
                IsBusy = false;
            }
        }
    }
}
