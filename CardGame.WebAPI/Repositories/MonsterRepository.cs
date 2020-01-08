using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class MonsterRepository : BaseRepository<Monster>
    {
        public MonsterRepository(CardGameContext cardGameContext) : base(cardGameContext)
        {
        }

        public override async Task<Monster> GetById(int id)
        {
            return await _cardGameContext.Set<Monster>()
                .Include(m => m.Deck)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }
    }
}
