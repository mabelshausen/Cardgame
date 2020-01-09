using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }
    }
}