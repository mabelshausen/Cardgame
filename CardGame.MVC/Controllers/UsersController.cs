using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGame.Lib.Dto;
using CardGame.Lib.Models;
using CardGame.Lib.Services;
using CardGame.MVC.Constants;
using CardGame.MVC.Services;
using CardGame.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserStateService _userStateService;
        private readonly string _baseUri = "https://localhost:5001/api/users/";

        public UsersController(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userStateService.UserState.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            var passwordValid = WebApiService.GetApiResult<bool>($"{_baseUri}{model.Email}/{model.Password}");

            if (!passwordValid)
            {
                ModelState.AddModelError("Password", FormConstants.PasswordValid);
                return View(model);
            }

            var user = WebApiService.GetApiResult<IEnumerable<UserDto>>(_baseUri)
                .Where(u => u.Email == model.Email)
                .FirstOrDefault();

            _userStateService.UserState = new UserState
            {
                Name = user.Name,
                Id = user.Id,
                IsLoggedIn = true,
                IsAdmin = user.IsAdmin
            };
            _userStateService.SaveUserState();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userStateService.UserState.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            User user = new User
            {
                Email = model.Email,
                Name = model.Name,
                Password = PasswordHasher.HashPassword(model.Password),
                IsAdmin = false
            };

            user = await WebApiService.PostCallApi<User, User>(_baseUri, user);

            _userStateService.UserState = new UserState
            {
                Name = user.Name,
                Id = user.Id,
                IsLoggedIn = true,
                IsAdmin = user.IsAdmin
            };
            _userStateService.SaveUserState();

            return RedirectToAction("Index", "Home");
        }
    }
}