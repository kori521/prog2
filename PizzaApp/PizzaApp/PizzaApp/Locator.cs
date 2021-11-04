using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PizzaApp.Data;
using PizzaApp.View;
using PizzaApp.ViewModel;

namespace PizzaApp
{
    public class Locator
    {
        private static IServiceProvider serviceProvider;
        public static void Initialize()
        {
            var services = new ServiceCollection();
            services.AddSingleton<SQLiteRepository, SQLiteConnection>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<HomeView>();
            services.AddTransient<FoodListView>();
            services.AddTransient<FoodListViewModel>();
            services.AddTransient<FoodView>();
            services.AddTransient<FoodViewModel>();
            services.AddTransient<OrderViewModel>();
            services.AddTransient<OrderView>();
            services.AddTransient<CartViewModel>();
            services.AddTransient<CartView>();
            services.AddTransient<CouponsViewModel>();
            services.AddTransient<CouponsView>();
            serviceProvider = services.BuildServiceProvider();
        }
        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
