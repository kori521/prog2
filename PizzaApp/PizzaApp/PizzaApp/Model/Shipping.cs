using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DevExpress.XamarinForms.DataForm;

namespace PizzaApp.Model
{
    public class Shipping
    {
        [PrimaryKey, AutoIncrement]
        [DataFormDisplayOptions(IsVisible = false)]
        public int id { get; set; }
        [DataFormItemPosition(RowOrder = 1, ItemOrderInRow = 1)]
        [DataFormDisplayOptions(LabelIcon = "name", GroupName = "Profile")]
        public string Firstname { get; set; }
        [DataFormItemPosition(RowOrder = 1, ItemOrderInRow = 2)]
        [DataFormDisplayOptions(IsLabelVisible = false, GroupName = "Profile")]
        public string Lastname { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public string Address { get; set; }
    }
}
