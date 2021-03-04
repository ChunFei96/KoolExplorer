using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EFDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public GenericRepository(EFDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return entities.ToList();
        }
        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public T GetLast()
        {
            return entities.ToList().LastOrDefault();
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
        }
        public void BulkInsert(List<T> entityList)
        {
            for(int i =0; i < entityList.Count(); i++)
            {
                T entity = entityList.ElementAt<T>(i);
                entities.Add(entity);
            }
                
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }

    }
}
