using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PizzaApp.Model
{
    public class History
    {
        public int orderid { get; set; }
        public int id { get; set; }
        public DateTime creationDate { get; set; }
        public List<Orders> orderlist { get; set; }
    }
}
