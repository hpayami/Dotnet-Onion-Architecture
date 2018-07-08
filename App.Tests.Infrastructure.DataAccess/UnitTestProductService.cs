using App.Domain.ServicesInterface;
using App.Domain.ServicesInterface.Framework;

using App.Infrastructure.DataAccess;
using App.Infrastructure.DataAccess.Framework;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Xunit;

namespace App.Tests.Infrastructure.DataAccess
{
    public class UnitTestProductService
    {
        private static string _connectionString;

        [Fact]
        public void Test1()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);

            var configuration = configBuilder.Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(_connectionString);

            using (CatalogueUnitOfWork catalogueUnitOfWork = new CatalogueUnitOfWork(new AppDataContext(optionsBuilder.Options)))            
            {
                IProductService productService = new ProductService(catalogueUnitOfWork);

                var categories = productService.GetCategories();
                Assert.NotEmpty(categories);

                foreach (var category in categories)
                    System.Diagnostics.Debug.WriteLine(string.Format("Category: {0}", category.CategoryName));

                var products = productService.GetProducts(1);
                Assert.NotEmpty(products);

                foreach (var product in products)
                    System.Diagnostics.Debug.WriteLine(string.Format("Product: {0} ${1}", product.ProductName, product.UnitPrice));

            }
        }
    }
}
