using App.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace App.Infrastructure.DataAccess.DataContext
{
    public class AppDataContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDataContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Kid's Shoes" },
                new Category() { CategoryId = 2, CategoryName = "Men's Shoes" },
                new Category() { CategoryId = 3, CategoryName = "Women's Shoes" },
                new Category() { CategoryId = 4, CategoryName = "Kid's Clothing" },
                new Category() { CategoryId = 5, CategoryName = "Men's Clothing" },
                new Category() { CategoryId = 6, CategoryName = "Women's Clothing" },
                new Category() { CategoryId = 7, CategoryName = "Outdoor" },
                new Category() { CategoryId = 8, CategoryName = "Kitchen" },
                new Category() { CategoryId = 9, CategoryName = "Toys" });

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ProductName = "Nike Runner", UnitPrice = 129.95M, Discontinued = false, CategoryId = 1 },
                new Product() { ProductId = 2, ProductName = "Reebok Runner", UnitPrice = 29.95M, Discontinued = false, CategoryId = 1 },
                new Product() { ProductId = 3, ProductName = "Adidas Runner", UnitPrice = 59.95M, Discontinued = false, CategoryId = 1 },
                new Product() { ProductId = 4, ProductName = "ASIC Runner", UnitPrice = 49.95M, Discontinued = false, CategoryId = 1 },
                new Product() { ProductId = 5, ProductName = "Blue Runner", UnitPrice = 39.95M, Discontinued = false, CategoryId = 1 },
                new Product() { ProductId = 6, ProductName = "Under Runner", UnitPrice = 59.95M, Discontinued = false, CategoryId = 1 });
        }
    }

    /// <summary>
    /// See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation#from-a-design-time-factory
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDataContext>
    {
        public AppDataContext CreateDbContext(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);

            var configuration = configBuilder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<AppDataContext>();
            builder.UseSqlServer(connectionString);

            return new AppDataContext(builder.Options);
        }
    }
}
