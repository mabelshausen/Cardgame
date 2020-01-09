using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.MVC.ViewModels
{
    public class UserState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsAdmin { get; set; }
    }
}
