using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PizzaApp.Model;
using System.Threading.Tasks;
using System.IO;

namespace PizzaApp.Data
{
    public class SQLiteConnection : SQLiteRepository
    {
        private SQLiteAsyncConnection _connection;
        public async Task Initialize()
        {
            if (_connection != null) return;
            _connection = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Pizza.db3"));
            try
            {
                await _connection.CreateTableAsync<Foods>();
                await _connection.CreateTableAsync<Orders>();
                //var pizza = new Foods()
                //{
                //    name = "Margarita",
                //    price = 1200,
                //    description = "paradicsomos alap, sajt"
                //};
                //await _connection.InsertAsync(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public async Task LoadTable()
        {
            //await Initialize();
            //var image = "";
            //var pizza = new Foods
            //{
            //    name = "Margarita",
            //    price = 1200,
            //    description = "paradicsomos alap, sajt"
            //};
            //await _connection.InsertOrReplaceAsync(pizza);
        }

        public async Task DeleteAll()
        {
            _ = await _connection.DeleteAllAsync<Orders>();
        }

        public Task<List<Foods>> GetFoods() =>
            _connection.Table<Foods>().ToListAsync();
        public Task<List<Orders>> GetOrders() =>
            _connection.Table<Orders>().ToListAsync();

    }
}
