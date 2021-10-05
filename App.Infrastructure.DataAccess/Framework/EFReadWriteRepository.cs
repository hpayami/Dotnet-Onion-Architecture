using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.Domain.Interfaces.Framework;

namespace App.Infrastructure.DataAccess.Framework
{
    /// <summary>
    /// Read Write Entity Framework Repository
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ReadWriteEFRespository<TKey, TEntity> : ReadOnlyEFRespository<TKey, TEntity>, IReadWriteRepository<TKey, TEntity> where TEntity : class
    {
        /// <summary>
        /// Read Write Entity Framework Repository constructor
        /// </summary>
        /// <param name="context"></param>
        public ReadWriteEFRespository(DbContext context) : base(context) { }

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);            
        }

        /// <summary>
        /// Add a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Remove an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}