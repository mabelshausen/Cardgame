using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.MVC.Controllers
{
    public class MonstersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}