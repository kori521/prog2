using PizzaApp.Data;
using PizzaApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaApp
{
    public partial class App : Application
    {
        public App()
        {
            DevExpress.XamarinForms.DataForm.Initializer.Init();
            InitializeComponent();
            Locator.Initialize();
            InitializeRepository();
            InitializeMainPage();
        }
        private void InitializeMainPage()
        {
            MainPage = new NavigationPage(Locator.Resolve<HomeView>());
        }
        private static void InitializeRepository()
        {
            SQLiteRepository SQLiteRepo = Locator.Resolve<SQLiteRepository>();
            //SQLiteRepo.Initialize();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
