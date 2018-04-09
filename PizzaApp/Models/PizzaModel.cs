using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class PizzaModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] Toppings { get; set; }
        public float Price { get; set; }
    }
}
