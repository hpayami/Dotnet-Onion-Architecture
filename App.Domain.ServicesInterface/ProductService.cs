using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities;
using App.Domain.RepoInterfaces;
using App.Domain.ServicesInterface.Framework;

namespace App.Domain.ServicesInterface
{
    public class ProductService : IProductService
    {
        // Repositories will be injected
        readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public ProductService(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public IEnumerable<Category> GetCategories()
        {
            // Return all categories
            IEnumerable<Category> categories = _catalogueUnitOfWork.CategoryRepository.GetAll();
            return categories;
        }

        public IEnumerable<Product> GetProducts(int? categoryId)
        {
            // Return products by category or none if no category specified
            IEnumerable<Product> products = Enumerable.Empty<Product>();

            if (categoryId != null)
            {
                products = _catalogueUnitOfWork.ProductRepository.Get(product => product.Category.CategoryId == categoryId);
            }

            return products;
        }
    }
}
