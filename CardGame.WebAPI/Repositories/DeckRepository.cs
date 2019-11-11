using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class DeckRepository : BaseRepository<Deck>
    {
        public DeckRepository(CardGameContext cardGameContext) : base(cardGameContext)
        {
        }
    }
}
