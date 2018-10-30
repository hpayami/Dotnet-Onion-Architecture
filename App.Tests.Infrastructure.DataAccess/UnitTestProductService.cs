using App.Domain.Application;
using App.Domain.Interfaces;
using App.Infrastructure.DataAccess;
using App.Infrastructure.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace App.Tests.Infrastructure.DataAccess
{
    public class UnitTestProductService
    {
        private static string _connectionString;

        [Fact]
        public void Test_ProductService()
        {
            DbContextOptions options = GetConnectionDetails();

            using (CatalogueUnitOfWork catalogueUnitOfWork = new CatalogueUnitOfWork(new AppDataContext(options)))
            {
                IProductService productService = new ProductService(catalogueUnitOfWork);

                var categories = productService.GetCategories();
                Assert.NotEmpty(categories);

                foreach (var category in categories)
                    System.Diagnostics.Debug.WriteLine(string.Format("Category {0}: {1}", category.CategoryId, category.CategoryName));

                var products = productService.GetProducts(1);
                Assert.NotEmpty(products);

                foreach (var product in products)
                    System.Diagnostics.Debug.WriteLine(string.Format("Product: {0} ${1}", product.ProductName, product.UnitPrice));
            }
        }

        private static DbContextOptions GetConnectionDetails()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddJsonFile("appsettings.json", optional: false);

            var configuration = configBuilder.Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(_connectionString);

            return optionsBuilder.Options;
        }
    }
}
