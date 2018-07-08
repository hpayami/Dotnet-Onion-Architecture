using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using App.Domain.Entities;

namespace App.Infrastructure.DataAccess.Framework
{
    public class AppDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
    public class AppDataDbContextFactory : IDesignTimeDbContextFactory<AppDataContext>
    {
        public AppDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDataContext>();
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Kam\\Source\\Repos\\OnionArchitecture\\App.Infrastructure.DataAccess\\App_Data\\CatalogueDatabase.mdf';Integrated Security=True");

            return new AppDataContext(builder.Options);
        }
    }
}
