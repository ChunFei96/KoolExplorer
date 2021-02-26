using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void BulkInsert(List<T> entity);
        void Update(T entity);
        void Delete(int id);
    }
}
