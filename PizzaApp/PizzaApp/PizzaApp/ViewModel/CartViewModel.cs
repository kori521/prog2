using PizzaApp.Model;
using PizzaApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PizzaApp.ViewModel
{
    public class CartViewModel : ViewModelBase
    {
        private ObservableCollection<Orders> order;
        public Foods food;
        public CartViewModel()
        {

        }
        public Foods SelectedProduct
        {
            get => null;
            set
            {
                if (value == null) return;
                NavigateToFoodView(value);
            }
        }
        public async void NavigateToFoodView(Foods value)
        {
            var foodView = Locator.Resolve<FoodView>();
            var foodViewModel = foodView.BindingContext as FoodViewModel;
            foodViewModel.food = value;
            await Navigation.PushAsync(foodView);
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
    }
}
