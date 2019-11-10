using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    class Effect : BaseEntity
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public decimal Chance { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
