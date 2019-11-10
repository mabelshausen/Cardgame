using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    class Deck : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
