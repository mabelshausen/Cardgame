using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    public class Deck : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<DeckCards> DeckCards { get; set; }
    }
}
