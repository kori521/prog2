using PizzaApp.Data;
using PizzaApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(SQLiteRepository sqliteRepository)
        {
            sqliteRepository.Initialize();
            InitPizzaCommand();
            InitCartCommand();
            InitCouponsCommand();
            InitOrdersCommand();
        }
        private void InitPizzaCommand()
        {
            PizzaCommand = new Command(async () => NavigateToPizzaView());
        }
        public async void NavigateToPizzaView()
        {
            var foodView = Locator.Resolve<FoodView>();
            var foodViewModel = foodView.BindingContext as FoodViewModel;
            await Navigation.PushAsync(foodView);
        }
        private void InitCartCommand()
        {
            CartCommand = new Command(async () => NavigateToCartView());
        }
        public async void NavigateToCartView()
        {
            var cartView = Locator.Resolve<CartView>();
            var cartViewModel = cartView.BindingContext as CartViewModel;
            await Navigation.PushAsync(cartView);
        }
        private void InitOrdersCommand()
        {
            OrdersCommand = new Command(async () => NavigateToOrderView());
        }
        public async void NavigateToOrderView()
        {
            var orderView = Locator.Resolve<OrderView>();
            var orderViewModel = orderView.BindingContext as OrderViewModel;
            await Navigation.PushAsync(orderView);
        }
        private void InitCouponsCommand()
        {
            CouponsCommand = new Command(async () => NavigateToCouponsView());
        }
        public async void NavigateToCouponsView()
        {
            var couponsView = Locator.Resolve<CouponsView>();
            var couponsViewModel = couponsView.BindingContext as CouponsViewModel;
            await Navigation.PushAsync(couponsView);
        }
        public ICommand PizzaCommand { get; set; }
        public ICommand CartCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand CouponsCommand { get; set; }

    }
}
