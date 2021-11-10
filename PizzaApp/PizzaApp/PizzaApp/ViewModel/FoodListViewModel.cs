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
    public class FoodListViewModel : ViewModelBase
    {
        public ObservableCollection<Foods> _foods;
        public Foods foods;
        private readonly SQLiteRepository sqliteRepository;
        public FoodListViewModel(SQLiteRepository sqliteRepository)
        {
            this.sqliteRepository = sqliteRepository;
            LoadFood();
        }
        private async void LoadFood()
        {
            try
            {
                var foods = await sqliteRepository.GetFoods()
                ?? Enumerable.Empty<Foods>();

                FoodTable = new ObservableCollection<Foods>(foods);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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

        public Foods Food
        {
            get => foods;
            set
            {
                foods = value;
                OnPropertyChanged();
            }
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
        public void RefreshCommand()
        {
            Refresh = new Command(async () => {
                LoadFood();
            });
        }
        private ICommand Refresh { get; set; }
    }
}
