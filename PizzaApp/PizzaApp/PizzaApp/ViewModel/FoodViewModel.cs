using PizzaApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PizzaApp.ViewModel
{
    public class FoodViewModel : ViewModelBase
    {
        ObservableCollection<Foods> _foods;
        public FoodViewModel()
        {

        }

        ObservableCollection<Foods> FoodTable
        {
            get => _foods;
            set
            {
                _foods = value;
                OnPropertyChanged();
            }
        }
    }
}
