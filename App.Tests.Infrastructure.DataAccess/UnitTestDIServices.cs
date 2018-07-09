using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Xunit;
using App.Domain.ServicesInterface.Framework;
using App.Infrastructure.DataAccess.Framework;
using App.Infrastructure.DataAccess;
using App.Domain.RepoInterfaces.Framework;
using App.Domain.ServicesInterface;
using App.Domain.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

/******************************************************************************
 Dependency Injection Unit Test: Using a test service
 ******************************************************************************/

namespace App.Tests.Infrastructure.DataAccess
{
    public class UnitTestDIServices
    {

        public class App
        {
            private readonly IProductService _productService;

            private readonly ILogger _logger;

            public App(IProductService productService, ILogger<App> logger)
            {
                _productService = productService;
                _logger = logger;
            }

            public void Start()
            {
                _logger.LogInformation("Starting...");

                var categories = _productService.GetCategories();
                Assert.NotEmpty(categories);

                foreach (var category in categories)
                    _logger.LogInformation(string.Format("Category {0}: {1}", category.CategoryId, category.CategoryName));

                var products = _productService.GetProducts(1);
                Assert.NotEmpty(products);

                foreach (var product in products)
                    _logger.LogInformation(string.Format("Product: {0} ${1}", product.ProductName, product.UnitPrice));

                _logger.LogInformation("Completed.");
            }
        }
        
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // configuration: connection string
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);

            var connectionString = configBuilder.Build()
                                                .GetConnectionString("DefaultConnection");

            // register objects
            serviceCollection.AddLogging(configure => configure.AddDebug())
                             .AddTransient<App>()
                             .AddTransient<ICatalogueUnitOfWork, CatalogueUnitOfWork>()
                             .AddTransient<IProductService, ProductService>()
                             .AddDbContext<AppDataContext>((options => options.UseSqlServer(connectionString)));
        }

        [Fact]
        public void TestProductServiceDI()
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Start();
        }
    }
}
