using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class MonstersController : Controller
    {
        private readonly UserStateService _userStateService;

        public MonstersController(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        public IActionResult Index()
        {
            if (!_userStateService.UserState.IsAdmin)
            {
                return NotFound();
            }

            return View();
        }
    }
}