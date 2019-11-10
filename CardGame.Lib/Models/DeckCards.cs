using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    public class DeckCards
    {
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int AmountOfCopies { get; set; }
    }
}
