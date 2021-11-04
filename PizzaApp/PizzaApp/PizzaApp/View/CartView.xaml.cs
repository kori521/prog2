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
    public partial class CartView : ContentPage
    {
        public CartView(CartViewModel cartViewModel)
        {
            InitializeComponent();
            cartViewModel.Navigation = Navigation;
            BindingContext = cartViewModel;
        }
    }
}