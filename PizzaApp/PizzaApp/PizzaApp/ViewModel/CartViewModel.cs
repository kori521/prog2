using PizzaApp.Data;
using PizzaApp.Model;
using PizzaApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PizzaApp.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        private readonly SQLiteRepository sqliteRepository;
        private ObservableCollection<Orders> order;
        public Orders ordercalc;
        public Foods food;
        public int total = 0;
        public CartViewModel(SQLiteRepository sqliteRepository)
        {
            this.sqliteRepository = sqliteRepository;
            LoadOrder();
            InitOrderCommand();
            InitDeleteCommand();
            InitRefreshCommand();
        }
        public async void LoadOrder()
        {
            try
            {
                var orderitem = await sqliteRepository.GetOrders()
                ?? Enumerable.Empty<Orders>();
                
                OrderItems = new ObservableCollection<Orders>(orderitem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public Orders SelectedProduct
        {
            get => null;
            set
            {
                if (value == null) return;

                NavigateToFoodView(value);
            }
        }
        public async void NavigateToFoodView(Orders value)
        {
            var foodView = Locator.Resolve<FoodView>();
            var foodViewModel = foodView.BindingContext as FoodViewModel;
            foodViewModel.orders = value;
            await Navigation.PushAsync(foodView);
        }
        public async void NavigateToShippingView()
        {
            var shippingView = Locator.Resolve<ShippingView>();
            var model = shippingView.BindingContext as ShippingViewModel;
            shippingView.setContent();
            await Navigation.PushAsync(shippingView);
        }
        public ObservableCollection<Orders> OrderItems
        {
            get => order;
            set
            {
                order = value;
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
        private void InitOrderCommand()
        {
            OrderCommand = new Command(async () => NavigateToShippingView());
        }
        private void InitDeleteCommand()
        {
            DeleteCommand = new Command(async () => await sqliteRepository.DeleteAll());
        }
        private void InitRefreshCommand()
        {
            RefreshCommand = new Command(async () => LoadOrder());
        }
        public ICommand OrderCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
    }
}
