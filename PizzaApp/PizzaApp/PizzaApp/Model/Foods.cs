using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PizzaApp.Model
{
    public class Foods
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}
