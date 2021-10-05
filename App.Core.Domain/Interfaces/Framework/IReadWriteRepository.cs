using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadWriteRepository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        // Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Remove     
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        // Update     
        void Update(TEntity entity);
    }
}