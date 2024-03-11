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
    public partial class ShippingView : ContentPage
    {
        private ShippingViewModel model;
        public ShippingView(ShippingViewModel model)
        {
            
            InitializeComponent();
            this.model = model;
            model.Navigation = Navigation;
            BindingContext = model;
            Form.DataObject = new Shipping();
        }
        public void setContent()
        {
            Form.DataObject = model.shipping;
        }
    }
}