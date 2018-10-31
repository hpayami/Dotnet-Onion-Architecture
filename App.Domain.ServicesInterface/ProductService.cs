using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Domain.Application
{
    public class ProductService : IProductService
    {
        // Repositories will be injected
        readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public ProductService(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            // Return all categories
            IEnumerable<Category> categories = await _catalogueUnitOfWork.CategoryRepository.FindAllAsync();

            return categories;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int? categoryId)
        {
            // Return products by category or none if no category specified
            IEnumerable<Product> products = Enumerable.Empty<Product>();

            if (categoryId != null)
            {
                products = await _catalogueUnitOfWork.ProductRepository.FindAsync(product => product.Category.CategoryId == categoryId);
            }

            return products;
        }
    }
}
