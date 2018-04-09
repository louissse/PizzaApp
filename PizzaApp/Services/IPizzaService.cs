using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Services
{
    public interface IPizzaService
    {
        Task<List<PizzaModel>> CreatePizzaMenu();
    }
}
