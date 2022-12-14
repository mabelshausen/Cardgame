using CardGame.Lib.Models;
using CardGame.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly CardGameContext _cardGameContext;

        public BaseRepository(CardGameContext cardGameContext)
        {
            _cardGameContext = cardGameContext;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _cardGameContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public IQueryable<T> GetAll()
        {
            return _cardGameContext.Set<T>().Where(e => !e.IsDeleted).AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            _cardGameContext.Set<T>().Add(entity);
            try
            {
                await _cardGameContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            entity.IsDeleted = true;
            return await Update(entity);
        }

        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return null;
            }
            return await Delete(entity);
        }

        public virtual async Task<T> Update(T entity)
        {
            _cardGameContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _cardGameContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }
    }
}
