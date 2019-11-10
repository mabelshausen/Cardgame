using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Deck> Decks { get; set; }
    }
}
