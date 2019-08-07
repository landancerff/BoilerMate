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
       
        public Command LoadSettingsCommand { get; set; }
     

        public ObservableCollection<RequirementSpec> SettingItem { get; set; }


        public SettingsViewModel()
        {
            SettingItem = new ObservableCollection<RequirementSpec>();
            IsBusy = false;
            LoadSettingsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<Settings, RequirementSpec>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as RequirementSpec;
                SettingItem.Add(newItem);
                await _context.SaveSettingsAsync(newItem);
            });
        }
        public async Task ExecuteLoadItemsCommand()
        {
          
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SettingItem.Clear();               
                
                var items = _context.GetAllRequirementValues();

                SettingItem.Add(items[0]);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //OnPropertyChanged(nameof(SettingItem));
                IsBusy = false;
            }
        }
    }
}
