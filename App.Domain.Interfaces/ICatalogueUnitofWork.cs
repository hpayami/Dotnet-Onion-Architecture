using System;
using App.Domain.Interfaces.Framework;

namespace App.Domain.Interfaces
{
    public interface ICatalogueUnitOfWork : IUnitOfWork, IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
