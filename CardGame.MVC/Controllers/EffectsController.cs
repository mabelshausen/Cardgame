using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class EffectsController : Controller
    {
        private readonly UserStateService _userStateService;

        public EffectsController(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        public IActionResult Index(int id)
        {
            return View();
        }
    }
}