using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int? id);
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
