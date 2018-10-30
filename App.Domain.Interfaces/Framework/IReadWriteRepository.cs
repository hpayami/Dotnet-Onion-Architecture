using System.Collections.Generic;

namespace App.Domain.Interfaces.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadWriteRepository<TKey, TEntity> : IReadonlyRespository<TKey, TEntity> where TEntity : class
    {
        // Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Remove     
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
