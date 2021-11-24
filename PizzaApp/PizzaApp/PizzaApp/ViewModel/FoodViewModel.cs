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
    public class FoodViewModel : ViewModelBase
    {
        private readonly SQLiteRepository sQLiteRepository;
        private ObservableCollection<Foods> _foods;
        public Foods food;
        private CartViewModel cart;
        public Orders orders;
        public FoodViewModel()
        {
            InitCartCommand();
            InitOrderCommand();
            orders = new Orders();
        }

        public ObservableCollection<Foods> FoodTable
        {
            get => _foods;
            set
            {
                _foods = value;
                OnPropertyChanged();
            }
        }

        public Foods FoodList
        {
            get => food;
            set
            {
                food = value;
                OnPropertyChanged();
            }
        }
        public Orders OrderItem
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

        public async void NavigateToCartView(Foods value)
        {
            var cartView = Locator.Resolve<CartView>();
            var cartViewModel = cartView.BindingContext as CartViewModel;
            orders.AddToOrders(value);
        }
        private void InitCartCommand()
        {
            CartCommand = new Command(async () => NavigateToCartView(FoodList));
        }
        public async void NavigateToOrderView(Foods value)
        {
            cart = new CartViewModel(sQLiteRepository);
            var cartView = Locator.Resolve<CartView>();
            var cartViewModel = cartView.BindingContext as CartViewModel;
            orders.AddToOrders(value);
            cart.LoadOrder();
            await Navigation.PushAsync(cartView);
        }
        private void InitOrderCommand()
        {
            OrderCommand = new Command(async () => NavigateToOrderView(FoodList));
        }
        public ICommand CartCommand { get; set; }
        public ICommand OrderCommand { get; set; }
    }
}
