using App.Domain.Interfaces;
using App.Infrastructure.DataAccess.DataContext;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess
{
    public class CatalogueUnitOfWork : ICatalogueUnitOfWork
    {
        protected readonly AppDataContext _context;

        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public CatalogueUnitOfWork(AppDataContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            // read-only
            return await _context.SaveChangesAsync(); ;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
