using Android.OS;
using BoilerMate.Models;
using BoilerMate.Services;
using BoilerMate.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoilerMate.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExportViewModel : BaseViewModel
    {
        readonly DatabaseActions.DatabaseManager _context = new DatabaseActions.DatabaseManager();
        public ObservableCollection<ExportModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ExportModel Export { get; set; }


        public ExportViewModel()
        {
            Title = "Exported Job";
            Items = new ObservableCollection<ExportModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ExportPage, ExportModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ExportModel;
                Items.Add(newItem);
                await _context.SaveExportAsync(newItem);
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
                var items = _context.GetAllExportsAsync();

                var outImg = new Image();

                foreach (var item in items)
                {                   
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
