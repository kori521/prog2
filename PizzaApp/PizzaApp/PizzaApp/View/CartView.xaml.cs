using PizzaApp.Model;
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
        public Orders orders = new Orders();
        public CartView(CartViewModel cartViewModel)
        {
            InitializeComponent();
            cartViewModel.Navigation = Navigation;
            BindingContext = cartViewModel;
            inittotal();
        }
        public void inittotal()
        {
            totalprice.Text = Convert.ToString(orders.calc());
        }

    }
}