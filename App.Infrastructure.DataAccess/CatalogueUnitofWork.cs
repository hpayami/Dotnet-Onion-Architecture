using App.Domain.RepoInterfaces;
using App.Infrastructure.DataAccess.Framework;

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

        public int Commit()
        {
            // read-only
            return 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
