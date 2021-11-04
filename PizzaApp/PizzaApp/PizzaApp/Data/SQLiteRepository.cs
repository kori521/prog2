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
        Task DeleteAll(Foods foodTable);
    }
}
