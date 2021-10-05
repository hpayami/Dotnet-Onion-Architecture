using App.Core.Application;
using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using App.Infrastructure.DataAccess;
using App.Infrastructure.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace App.Tests.Infrastructure.DataAccess
{
    public class UnitTestProductService
    {
        private static string _connectionString;

        [Fact]
        public async Task Test_GetCategoriesAndProducts()
        {
            // mock the logger
            Mock<ILogger<ProductService>> mock = new Mock<ILogger<ProductService>>();
            ILogger<ProductService> logger = mock.Object;

            DbContextOptions options = GetConnectionDetails();

            using (CatalogueUnitOfWork catalogueUnitOfWork = new CatalogueUnitOfWork(new AppDataContext(options)))
            {
                IProductService productService = new ProductService(logger, catalogueUnitOfWork);

                var categories = await productService.GetCategoriesAsync();
                Assert.NotEmpty(categories);

                foreach (var category in categories)
                    System.Diagnostics.Debug.WriteLine(string.Format("Category {0}: {1}", category.CategoryId, category.CategoryName));

                var products = await productService.GetProductsAsync(1);
                Assert.NotEmpty(products);

                foreach (var product in products)
                    System.Diagnostics.Debug.WriteLine(string.Format("Product: {0} ${1}", product.ProductName, product.UnitPrice));
            }
        }

        [Fact]
        public async Task Test_AddProduct()
        {
            // mock the logger
            Mock<ILogger<ProductService>> mock = new Mock<ILogger<ProductService>>();
            ILogger<ProductService> logger = mock.Object;

            DbContextOptions options = GetConnectionDetails();

            using (CatalogueUnitOfWork catalogueUnitOfWork = new CatalogueUnitOfWork(new AppDataContext(options)))
            {
                IProductService productService = new ProductService(logger, catalogueUnitOfWork);

                Category category = await productService.AddCategory($"New Category {DateTime.Now.Ticks}");
                await catalogueUnitOfWork.CommitAsync();

                System.Diagnostics.Debug.WriteLine($"{category.CategoryId} {category.CategoryName}");
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