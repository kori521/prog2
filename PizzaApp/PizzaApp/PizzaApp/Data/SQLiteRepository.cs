using PizzaApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Data
{
    public interface SQLiteRepository
    {
        Task Initialize();
        Task LoadTable();
        Task DeleteAll();
        Task<List<Foods>> GetFoods();
        Task<List<Orders>> GetOrders();
    }
}
