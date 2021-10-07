using App.Core.Domain.Interfaces;
using App.Infrastructure.DataAccess.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess
{
    public class CatalogueUnitOfWork : ICatalogueUnitOfWork
    {
        protected readonly AppDataContext _context;

        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IBulkImportRepository BulkImportRepository { get; }

        public CatalogueUnitOfWork(AppDataContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            BulkImportRepository = new BulkImportRepository(_context);
        }

        public async Task<int> CommitAsync()
        {        
            return await _context.SaveChangesAsync(); ;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}