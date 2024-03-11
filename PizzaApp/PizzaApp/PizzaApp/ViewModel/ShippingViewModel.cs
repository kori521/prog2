using PizzaApp.Data;
using PizzaApp.Model;
using PizzaApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaApp.ViewModel
{
    public class ShippingViewModel : ViewModelBase
    {
        private readonly SQLiteRepository sqliterepository;
        private Shipping _shipping;
        public ShippingViewModel(SQLiteRepository sqliterepository)
        {
            this.sqliterepository = sqliterepository;
            InitThanksCommand();
        }
        public Shipping shipping
        {
            get => _shipping;
            set
            {
                _shipping = value;
                OnPropertyChanged();
            }
        }
        private void InitThanksCommand()
        {
            ThankYouCommand = new Command(async () => NavigateToThankView());
        }

        private async void NavigateToThankView()
        {
            var thanks = Locator.Resolve<ThankYouView>();
            await Navigation.PushAsync(thanks);
        }

        public ICommand ThankYouCommand { get; set; }
    }
}
