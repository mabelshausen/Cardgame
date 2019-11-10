using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    public class Monster : BaseEntity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
    }
}
