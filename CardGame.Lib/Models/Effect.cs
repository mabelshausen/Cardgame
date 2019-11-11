using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    public class Effect : BaseEntity
    {
        public string Code { get; set; }
        public int Power { get; set; }
        public decimal Chance { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
