using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using App.Domain.Interfaces.Framework;

namespace App.Infrastructure.DataAccess.Framework
{
    /// <summary>
    /// Entity Framework Read Write Repository
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EFReadWriteRepository<TKey, TEntity> : IReadWriteRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public EFReadWriteRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
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

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
