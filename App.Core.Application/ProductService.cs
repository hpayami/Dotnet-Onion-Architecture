using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Application
{
    public class ProductService : IProductService
    {
        // inject the dependencies
        private readonly ILogger<ProductService> _logger;

        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public ProductService(ILogger<ProductService> logger, ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _logger = logger;
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            _logger.LogInformation("Calling: CategoryRepository.FindAllAsync()");
            // Return all categories
            return await _catalogueUnitOfWork.CategoryRepository.FindAllAsync(); ;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int? categoryId)
        {
            _logger.LogInformation("Calling: ProductRepository.FindAsync()");

            // Return products by category or none if no category specified
            if (categoryId != null)
                return await _catalogueUnitOfWork.ProductRepository.FindAsync(product => product.Category.CategoryId == categoryId);
            else
                return Enumerable.Empty<Product>();
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            _logger.LogInformation("Calling: CategoryRepository.GetCategoryWithProductsAsync()");

            return await _catalogueUnitOfWork.CategoryRepository.GetCategoryWithProductsAsync();
        }

        public async Task<Category> AddCategory(string name)
        {
            _logger.LogInformation("Calling: CategoryRepository.AddAsync()");

            Category category = new Category() { CategoryName = name };

            _catalogueUnitOfWork.CategoryRepository.Add(category);
            await _catalogueUnitOfWork.CommitAsync();

            return category;
        }
    }
}