using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ecommerce.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}