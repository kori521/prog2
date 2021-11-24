using PizzaApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaApp.ViewModel
{
    public class ThankYouViewModel : ViewModelBase
    {
        public ThankYouViewModel()
        {
            InitContinueCommand();
        }
        private void InitContinueCommand()
        {
            ContinueCommand = new Command(async () => NavigateToHomeView());
        }

        private async void NavigateToHomeView()
        {
            var main = Application.Current.MainPage.Navigation;
            var homeView = Locator.Resolve<HomeView>();
            var homeViewModel = homeView.BindingContext as HomeViewModel;
            await main.PopToRootAsync();
        }

        public ICommand ContinueCommand { get; set; }
    }
}
