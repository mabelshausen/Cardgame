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

        public async Task<Deck> GetByIdWithCards(int id)
        {
            return await _cardGameContext.Set<Deck>()
                .Include(d => d.DeckCards)
                .ThenInclude(dc => dc.Card)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<DeckCards> Add(DeckCards deckCards)
        {
            deckCards.Card = null;
            _cardGameContext.Set<DeckCards>().Add(deckCards);
            try
            {
                await _cardGameContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return deckCards;
        }

        public virtual async Task<DeckCards> Update(DeckCards deckCards)
        {
            _cardGameContext.Entry(deckCards).State = EntityState.Modified;
            try
            {
                await _cardGameContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return deckCards;
        }

        public async Task<DeckCards> Delete(int deckId, int cardId)
        {
            var entity = await _cardGameContext.Set<DeckCards>()
                .Where(dc => dc.DeckId == deckId && dc.CardId == cardId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return null;
            }

            _cardGameContext.Set<DeckCards>().Remove(entity);
            await _cardGameContext.SaveChangesAsync();

            return entity;
        }
    }
}
