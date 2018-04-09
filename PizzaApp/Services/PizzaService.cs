using PizzaApp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Services
{
    //This service will handle the initial creation of the pizza menu. When implemented it will also handle
    //adding pizzas to the menu and deleting them again. 
    public class PizzaService : IPizzaService
    {
        private static ConcurrentBag<PizzaModel> _pizzaStore;

        static PizzaService()
        {
            _pizzaStore = new ConcurrentBag<PizzaModel>();
        }

        public async Task<List<PizzaModel>> CreatePizzaMenu()
        {
            var pizzaMenu = new List<PizzaModel>();
            for (int i = 0; i < 6; i++)
            {
                var pizza = new PizzaModel() {
                    Id = new Guid(),
                    Name = "Pizza 1",
                    Price = 60f,
                    Toppings = new String[] { "Tomat", "Ost", "Topping 1", "Topping 2" }
                };
                pizzaMenu.Add(pizza);
                _pizzaStore.Add(pizza);
            }
            return pizzaMenu;
        }
    }
}
