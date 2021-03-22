using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace DAL
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EFDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public GenericRepository(EFDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            entities = context.Set<T>();
            _httpContextAccessor = httpContextAccessor;
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

        public virtual List<T> GetAndInclude(
       Expression<Func<T, bool>> filter = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.AsNoTracking().ToList();
            }
        }

        public virtual List<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<T> query = entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) != null ?
                               _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : string.Empty;
            entities.Add(entity);
        }
        public void BulkInsert(List<T> entityList)
        {
            for(int i =0; i < entityList.Count(); i++)
            {
                T entity = entityList.ElementAt<T>(i);
                entities.Add(entity);
            }
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) != null ?
                               _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : string.Empty;
            entity.ModifiedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) != null ?
                                _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : string.Empty;
            entity.ModifiedTimeStamp = DateTime.Now;
            entities.Update(entity);
        }
        public void Delete(int id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
        }

        private IEnumerable<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            var query = context as IQueryable<T>; // context = dbContext.Set<TEntity>()

            query = properties
                       .Aggregate(query, (current, property) => current.Include(property));

            return query.AsNoTracking().ToList(); //readonly
        }

    }
}
