using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadWriteRepository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        // Add
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        // Remove     
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        // update     
        Task UpdateAsync(TEntity entity);
    }
}