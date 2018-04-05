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
    public class HomeController : Controller
    {
        readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userModel);
                return RedirectToAction(nameof(EmailConfirmation), new { userModel.Email });
            }
            else
            {
                return View(userModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EmailConfirmation(string email)
        {
           
            var user = await _userService.GetUserByEmail(email);

            if (user?.IsEmailConfirmed == true)
            {
                Request.HttpContext.Session.SetString("email", email);
                return RedirectToAction("Index", "PizzaMenu", new { email = email });
            }
                

            ViewBag.Email = email; //To display the email in the waiting view

            return View();
        }
    }
}