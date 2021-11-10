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
        private SQLiteRepository sqliteRepository;
        ObservableCollection<Foods> _foods;
        public Foods food;
        public FoodViewModel()
        {
            InitCartCommand();
            InitOrderCommand();
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

        public async void NavigateToCartView(Foods value)
        {
            var cartView = Locator.Resolve<CartView>();
            var cartViewModel = cartView.BindingContext as CartViewModel;
            cartViewModel.food = value;
            //await sqliteRepository.AddOrUpdateCart(value);
            
        }
        private void InitCartCommand()
        {
            CartCommand = new Command(async () => NavigateToCartView(new Foods()));
        }
        public async void NavigateToOrderView(Foods value)
        {
            var cartView = Locator.Resolve<CartView>();
            var cartViewModel = cartView.BindingContext as CartViewModel;
            cartViewModel.food = value;
            //await sqliteRepository.AddOrUpdateCart(value);
            await Navigation.PushAsync(cartView);
        }
        private void InitOrderCommand()
        {
            OrderCommand = new Command(async () => NavigateToOrderView(new Foods()));
        }
        public ICommand CartCommand { get; set; }
        public ICommand OrderCommand { get; set; }
    }
}
