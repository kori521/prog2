using PizzaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodListView : ContentPage
    {
        public FoodListView(FoodListViewModel foodListViewModel)
        {
            InitializeComponent();
            foodListViewModel.Navigation = Navigation;
            BindingContext = foodListViewModel;
        }

        private void Totop_Clicked(object sender, EventArgs e)
        {
            Collection.ScrollTo(0);
        }
    }
}