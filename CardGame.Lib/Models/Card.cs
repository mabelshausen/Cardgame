using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DeckCards> DeckCards { get; set; }
        public ICollection<Effect> Effects { get; set; }
    }
}
