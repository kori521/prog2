using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PizzaApp.Model;
using System.Threading.Tasks;

namespace PizzaApp.Data
{
    public class SQLiteConnection : SQLiteRepository
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteConnection()
        {

        }

        public async Task Initialize()
        {
            if (_connection != null) return;
            _connection = new SQLiteAsyncConnection("PizzaApp.db3");
            try
            {
                await _connection.CreateTableAsync<Foods>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        //public Task<List<Foods>> GetProducts() =>
        //   _connection.Table<Foods>().Where(c =>
        //               !c.id
        //   ).ToListAsync();

        public async Task DeleteAll(Foods foodTable)
        {
            _ = await _connection.DeleteAllAsync<Foods>();
        }

    }
}
