using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

// Tools -> NuGet Package Manager -> Pacakage Manager Console
//      Install-Package Microsoft.Extensions.Logging
//      Install-Pacakge Microsoft.Extensions.Logging.Debug
//      Install-Package Microsoft.Extensions.DependencyInjection

//      Uninstall-Package Microsoft.Extensions.Logging.Console

using Xunit;

namespace App.Tests.Infrastructure.DataAccess
{
    public interface ITestService
    {
        void Run();
    }

    public class TestService : ITestService
    {
        private readonly ILogger _logger;

        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Test service is running");
        }
    }

    public class App
    {
        private readonly ITestService _testService;

        private readonly ILogger _logger;

        public App(ITestService testService, ILogger<App> logger)
        {
            _testService = testService;
            _logger = logger;
        }

        public void Start()
        {
            _logger.LogInformation("Starting...");
            _testService.Run();
            _logger.LogInformation("Completed.");
        }
    }

    public class UnitTestDependency
    {
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // register 
            serviceCollection.AddLogging(configure => configure.AddDebug())
                             .AddTransient<App>()
                             .AddTransient<ITestService, TestService>();
        }

        [Fact]
        public void Test1()
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
