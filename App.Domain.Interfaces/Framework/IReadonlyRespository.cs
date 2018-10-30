using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.Domain.Interfaces.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadonlyRespository<TKey, TEntity> where TEntity : class
    {
        // Read
        TEntity Get(TKey key);        
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int pageIndex, int pageSize);        
    }
}
