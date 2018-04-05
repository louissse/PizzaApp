using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must type in your name.")]
        public String Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "You must type in your e-mail."), DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must set a password."), DataType(DataType.Password)]
        public String Password { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
