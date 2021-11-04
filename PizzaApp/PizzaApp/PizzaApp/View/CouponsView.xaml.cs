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
    public partial class CouponsView : ContentPage
    {
        public CouponsView(CouponsViewModel couponsViewModel)
        {
            InitializeComponent();
            couponsViewModel.Navigation = Navigation;
            BindingContext = couponsViewModel;
        }
    }
}