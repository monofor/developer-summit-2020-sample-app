using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EcommerceContext _context;
        private readonly DbSet<TEntity> _entity;

        public Repository(EcommerceContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = _entity.Include(include);
            }

            return query ?? _entity;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate).AsQueryable();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}