using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using SQLite;

namespace PizzaApp.Model
{
    [Table("megrendeles")]
    public class Orders
    {
        public SQLiteConnection db = new SQLiteConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Pizza.db3"));

        private int histid = 0;
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double total { get; set; }
        public double piece { get; set; }
        private History history;
        public void SaveOrderToHistory()
        {
            //TODO: eleg lesz az összeg meg a creation date
            var length = db.Query<Orders>("select count(*) from megrendeles");
            history = new History();
            history.creationDate = DateTime.Now;
            history.orderid = histid;
            history.orderlist = db.Query<Orders>("select * from megrendeles");
            db.DeleteAll<Orders>();
            histid++;
        }
        public void AddToOrders(Foods food)
        {
            pid = food.id;
            name = food.name;
            description = food.description;
            price = food.price;
            total = total + food.price;
            db.Insert(this);
        }

    }

}
