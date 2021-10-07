using App.Core.Domain.Interfaces.Framework;
using System;

namespace App.Core.Domain.Interfaces
{
    public interface ICatalogueUnitOfWork : IUnitOfWork, IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IBulkImportRepository BulkImportRepository { get; }
    }
}