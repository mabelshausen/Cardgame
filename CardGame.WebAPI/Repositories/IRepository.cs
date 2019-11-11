using CardGame.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.WebAPI.Repositories
{
    interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAll();
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}
