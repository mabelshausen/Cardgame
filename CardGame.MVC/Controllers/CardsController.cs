using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class CardsController : Controller
    {
        private readonly UserStateService _userStateService;

        public CardsController(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}