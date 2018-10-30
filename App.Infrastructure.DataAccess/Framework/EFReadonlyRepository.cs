using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using App.Domain.Interfaces.Framework;

namespace App.Infrastructure.DataAccess.Framework
{
    /// <summary>
    /// Entity Framework Readonly Repository
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EFReadonlyRepository<TKey, TEntity> : IReadonlyRespository<TKey, TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public EFReadonlyRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().Where(filter);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize)
        {
            return Context.Set<TEntity>().Where(filter).Skip((pageSize - 1) * pageIndex).Take(pageSize);
        }

        public TEntity Get(TKey key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll(int pageIndex, int pageSize)
        {
            return Context.Set<TEntity>().Skip((pageSize - 1) * pageIndex).Take(pageSize);
        }
    }
}
