using System;

using App.Domain.RepoInterfaces.Framework;

namespace App.Domain.RepoInterfaces
{
    public interface ICatalogueUnitOfWork : IUnitOfWork, IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
