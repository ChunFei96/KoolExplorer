using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        List<T> GetAndInclude(
       Expression<Func<T, bool>> filter = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        void BulkInsert(List<T> entity);
        void Update(T entity);
        void Delete(int id);
    }
}
