using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PizzaApp.Model
{
    public class Orders
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double total { get; set; }
        public double piece { get; set; }
    }
}
