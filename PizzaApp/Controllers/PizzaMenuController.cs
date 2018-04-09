using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using PizzaApp.Services;

namespace PizzaApp.Controllers
{
    public class PizzaMenuController : Controller
    {
        readonly IUserService _userService;
        readonly IPizzaService _pizzaService;

        public PizzaMenuController(IUserService userService, IPizzaService pizzaService)
        {
            _userService = userService;
            _pizzaService = pizzaService;
        }

        public async Task<IActionResult> Index()
        {
            PizzaMenuModel menu = new PizzaMenuModel();
            menu.AllPizzas = await _pizzaService.CreatePizzaMenu();

            return View(menu);
        }
    }
}