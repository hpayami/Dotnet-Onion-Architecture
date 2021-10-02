using System;
using App.Core.Domain.Interfaces.Framework;

namespace App.Core.Domain.Interfaces
{
    public interface ICatalogueUnitOfWork : IUnitOfWork, IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
