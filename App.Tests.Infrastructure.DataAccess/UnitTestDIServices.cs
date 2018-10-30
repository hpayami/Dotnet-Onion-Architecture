using App.Domain.Interfaces;
using App.Domain.Application;
using App.Infrastructure.DataAccess;
using App.Infrastructure.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

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
        
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // register objects
            services.AddLogging(configure => configure.AddDebug())
                    .AddTransient<App>()
                    .AddTransient<ICatalogueUnitOfWork, CatalogueUnitOfWork>()
                    .AddTransient<IProductService, ProductService>()
                    .AddDbContext<AppDataContext>((options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))));
        }

        [Fact]
        public void TestProductServiceDI()
        {
            // service collection and configuration settings
            var services = new ServiceCollection();

            var configurationBuilder = new ConfigurationBuilder();
            var configuration = configurationBuilder.AddJsonFile("appsettings.json", optional: false)
                                                    .Build();
            // setup dependency
            ConfigureServices(services, configuration);            
            var serviceProvider = services.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Start();
        }
    }
}
