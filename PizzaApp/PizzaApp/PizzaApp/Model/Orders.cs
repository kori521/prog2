using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PizzaApp.View;
using PizzaApp.ViewModel;
using SQLite;

namespace PizzaApp.Model
{
    [Table("megrendeles")]
    public class Orders
    {
        public SQLiteConnection db = new SQLiteConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Pizza.db3"));

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double piece { get; set; }
        public double total{ get; set; }
        [Ignore]
        public List<double> totallist { get; set; }
        public double finaltotal = 0;

        public void AddToOrders(Foods food)
        {
            if(totallist == null) totallist = new List<double>();
            pid = food.id;
            name = food.name;
            description = food.description;
            price = food.price;
            totallist.Add(price);
            for (int i = 0; i < totallist.Count; i++)
            {
                total += totallist[i];
            }
            finaltotal = total;
            db.Insert(this);
        }
        public double calc()
        {
            return finaltotal;
        }

    }

}
