using App.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadOnlyRepository<TKey, TEntity> : IDisposable where TEntity : class
    {
        // Read
        Task<TEntity> FindAsync(TKey key);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);
        
        Task<IEnumerable<TEntity>> FindAsync<TOrderKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderKey>> order, OrderDirection orderDirection);
        Task<PaginatedList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize);
        Task<PaginatedList<TEntity>> FindAsync<TOrderKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderKey>> order, OrderDirection orderDirection, int pageIndex, int pageSize);

        Task<IEnumerable<TEntity>> FindAllAsync();        
        Task<PaginatedList<TEntity>> FindAllAsync(int pageIndex, int pageSize);
        Task<PaginatedList<TEntity>> FindAllAsync<TOrderKey>(Expression<Func<TEntity, TOrderKey>> order, OrderDirection orderDirection, int pageIndex, int pageSize);

        Task<IEnumerable<TEntity>> FindAllIncludeAsync(params Expression<Func<TEntity, object>>[] includes);
    }
}
