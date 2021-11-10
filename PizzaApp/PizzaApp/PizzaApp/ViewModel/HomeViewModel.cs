using PizzaApp.Data;
using PizzaApp.Model;
using PizzaApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Foods> food;
        public HomeViewModel(SQLiteRepository sqliteRepository)
        {
            sqliteRepository.Initialize();
            sqliteRepository.LoadTable();
            InitPizzaCommand();
            InitCartCommand();
            InitCouponsCommand();
            InitOrdersCommand();
        }
        private void InitPizzaCommand()
        {
            PizzaCommand = new Command(async () => NavigateToPizzaView(new Foods()));
        }
        public async void NavigateToPizzaView(Foods value)
        {
            var foodListView = Locator.Resolve<FoodListView>();
            var foodListViewModel = foodListView.BindingContext as FoodListViewModel;
            foodListViewModel.foods = value;
            await Navigation.PushAsync(foodListView);
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

        public ObservableCollection<Foods> FoodTable
        {
            get => food;
            set
            {
                food = value;
                OnPropertyChanged();
            }
        }
        public ICommand PizzaCommand { get; set; }
        public ICommand CartCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand CouponsCommand { get; set; }

    }
}
