using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<Card> GetById(int id)
        {
            return await _cardGameContext.Cards
                .Include(c => c.Effects)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public override async Task<IEnumerable<Card>> ListAll()
        {
            return await GetAll()
                .Include(c => c.Effects)
                .ToListAsync();
        }
    }
}
