using App.Domain.Interfaces;
using App.Domain.Interfaces.Framework;
using App.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Framework
{
    /// <summary>
    /// Read Only Entity Framework Repository
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ReadOnlyEFRespository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        /// <summary>
        /// Read Only Entity Framework Repository constructor
        /// </summary>
        /// <param name="context"></param>
        public ReadOnlyEFRespository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> FindAsync(TKey key)
        {
            return await _context.Set<TEntity>().FindAsync(key);
        }

        /// <summary>
        /// Find using a filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).ToListAsync(); ;
        }

        /// <summary>
        /// Find using a filter, paginate the results
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync<TOrderKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderKey>> order, OrderDirection orderDirection)
        {
            int count = await _context.Set<TEntity>().Where(filter).CountAsync();
            List<TEntity> items;

            if (orderDirection == OrderDirection.Asending)
                items = await _context.Set<TEntity>().Where(filter).OrderBy(order).ToListAsync();
            else
                items = await _context.Set<TEntity>().Where(filter).OrderByDescending(order).ToListAsync();

            return items;
        }


        /// <summary>
        /// Find using a filter, paginate the results
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PaginatedList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize)
        {
            int count = await _context.Set<TEntity>().Where(filter).CountAsync();
            List<TEntity> items = await _context.Set<TEntity>().Where(filter).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
        }

        /// <summary>
        /// Find using a filter, paginate the results
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PaginatedList<TEntity>> FindAsync<TOrderKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderKey>> order, OrderDirection orderDirection, int pageIndex, int pageSize)
        {
            int count = await _context.Set<TEntity>().Where(filter).CountAsync();
            List<TEntity> items;

            if (orderDirection == OrderDirection.Asending)
                items = await _context.Set<TEntity>().Where(filter).OrderBy(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            else
                items = await _context.Set<TEntity>().Where(filter).OrderByDescending(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
        }

        /// <summary>
        /// Return all records
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Return all records with includes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAllIncludeAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();

            IQueryable<TEntity> query = null;

            foreach (Expression<Func<TEntity, object>> includeExpression in includes)
            {
                query = dbSet.Include(includeExpression);
            }

            if (query != null)
                return await query.ToListAsync();
            else
                return await dbSet.ToListAsync();
        }

        /// <summary>
        /// Return all records, paginate the results
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PaginatedList<TEntity>> FindAllAsync(int pageIndex, int pageSize)
        {
            int count = await _context.Set<TEntity>().CountAsync();
            List<TEntity> items = await _context.Set<TEntity>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
        }

        /// <summary>
        /// Return all records, paginate the results
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PaginatedList<TEntity>> FindAllAsync<TOrderKey>(Expression<Func<TEntity, TOrderKey>> order, OrderDirection orderDirection, int pageIndex, int pageSize)
        {
            int count = await _context.Set<TEntity>().CountAsync();
            List<TEntity> items;

            if (orderDirection == OrderDirection.Asending)
                items = await _context.Set<TEntity>().OrderBy(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            else
                items = await _context.Set<TEntity>().OrderByDescending(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
        }

        /// <summary>
        /// Dispose of the context since we are done with the repository
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}