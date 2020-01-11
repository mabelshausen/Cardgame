using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class DecksController : Controller
    {
        private readonly UserStateService _userStateService;

        public DecksController(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        public IActionResult Index(int? id)
        {
            if (!_userStateService.UserState.IsAdmin && id == null)
            {
                return NotFound();
            }

            if (!_userStateService.UserState.IsAdmin && id != _userStateService.UserState.Id)
            {
                return NotFound();
            }

            return View();
        }

        public IActionResult Builder(int id)
        {
            if (!_userStateService.UserState.IsAdmin || _userStateService.UserState.Id == id)
            {
                return NotFound();
            }

            return View();
        }
    }
}