using CardGame.MVC.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = FormConstants.EmailDisplay)]
        [Required(ErrorMessage = FormConstants.EmailRequired)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = FormConstants.PasswordDisplay)]
        [Required(ErrorMessage = FormConstants.PasswordRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
