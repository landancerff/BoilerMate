using BoilerMate.Models;

namespace BoilerMate.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public JobReport Item { get; set; }       

        public ItemDetailViewModel(JobReport item = null)
        {
            Title = item?.Text;
            Item = item;             
        }    
    }
}
