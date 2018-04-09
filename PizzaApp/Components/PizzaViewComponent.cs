using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Components
{
    [ViewComponent(Name = "Pizza")]
    public class PizzaViewComponent : ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var pizza = new PizzaModel()
        //    {
        //        Id = new Guid(),
        //        Name = "Default Pizza",
        //        Toppings = new string[] {"Topping 1", "Topping 2", "Topping 3"},
        //        Price = 55f
        //    };
        //    return View(pizza);

        //}
        public async Task<IViewComponentResult> InvokeAsync(PizzaModel pizza)
        {
            return View(pizza);
        }
    }
}
