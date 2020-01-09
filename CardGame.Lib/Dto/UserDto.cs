using CardGame.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Deck> Decks { get; set; }
    }
}
