using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class CardRepository : BaseRepository<Card>
    {
        public CardRepository(CardGameContext cardGameContext) : base(cardGameContext)
        {
        }
    }
}
