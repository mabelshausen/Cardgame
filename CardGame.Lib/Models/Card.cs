﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    class Card
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DeckCards> DeckCards { get; set; }
    }
}
