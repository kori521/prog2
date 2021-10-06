using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaApp.ViewModel
{
    public class ViewModelBase : BindableObject
    {
        public INavigation Navigation { get; set; }
    }
}
