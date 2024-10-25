using DevExpress.XamarinForms.Editors;
using PizzaApp.Model;
using PizzaApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShippingView : ContentPage
    {
        private ShippingViewModel model;
        bool acceptable = false;
   
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

        private void phoneBox_TextChanged(object sender, EventArgs e)
        {
            // Regular expression pattern for phone number validation
            string phonePattern = @"^\+?\d{10,15}$"; // Modify this pattern according to your needs
            bool isValid = Regex.IsMatch(phoneBox.Text, phonePattern);

            if (isValid)
            {
                phoneBox.BorderColor = Color.Green; // Hide error message if valid
                acceptable = true;
            }
            else
            {
                phoneBox.BorderColor = Color.Red;
                // Show error message if invalid
            }
        }
    }
}