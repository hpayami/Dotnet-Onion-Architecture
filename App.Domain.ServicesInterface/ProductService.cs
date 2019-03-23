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
            return await _catalogueUnitOfWork.CategoryRepository.FindAllAsync(); ;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int? categoryId)
        {
            // Return products by category or none if no category specified
            if (categoryId != null)
                return await _catalogueUnitOfWork.ProductRepository.FindAsync(product => product.Category.CategoryId == categoryId);
            else
                return Enumerable.Empty<Product>();
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return await _catalogueUnitOfWork.CategoryRepository.GetCategoryWithProductsAsync();
        }
    }
}
