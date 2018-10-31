﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using App.Domain.Interfaces;
using App.Domain.Application;
using App.Infrastructure.DataAccess;
using App.Infrastructure.DataAccess.DataContext;
using System.Threading.Tasks;

namespace App.Client.ConsoleUI
{
    class Program
    {
        static async Task GetCatalogue()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);

            var configuration = configBuilder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);

            using (CatalogueUnitOfWork catalogueUnitOfWork = new CatalogueUnitOfWork(new AppDataContext(optionsBuilder.Options)))
            {
                IProductService productService = new ProductService(catalogueUnitOfWork);

                var categories = await productService.GetCategoriesAsync();

                foreach (var category in categories)
                    Console.WriteLine(string.Format("Category {0}: {1}", category.CategoryId, category.CategoryName));

                var products = await productService.GetProductsAsync(1);

                foreach (var product in products)
                    Console.WriteLine(string.Format("Product: {0} ${1}", product.ProductName, product.UnitPrice));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Open Catalogue...");

            GetCatalogue().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
