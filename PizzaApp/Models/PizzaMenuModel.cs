using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class PizzaMenuModel
    {
        public List<PizzaModel> AllPizzas { get; set; }

        public PizzaMenuModel()
        {
            AllPizzas = new List<PizzaModel>();
        }
    }
}
