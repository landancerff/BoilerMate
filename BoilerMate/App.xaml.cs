using BoilerMate.Views;
using SQLite;
using Xamarin.Forms;

namespace BoilerMate
{
    public partial class App : Application
    {       

        public App()
        {
            InitializeComponent(); 
         
            MainPage = new MainPage();
        
    }    


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        //public App(ISQLitePlatform sqliteplatform, string dbPath)
        //{
        //    SQLiteConnection conn = new SQLiteConnection(sqliteplatform, dbPath);
        //}
    }


}
