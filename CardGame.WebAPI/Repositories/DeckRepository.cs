using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Deck> GetAllByUserId(int id)
        {
            return _cardGameContext.Set<Deck>()
                .Where(d => !d.IsDeleted && d.UserId == id)
                .AsNoTracking();
        }
    }
}
