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
    }

    /// <summary>
    /// See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation#from-a-design-time-factory
    /// </summary>
    public class AppDataDbContextFactory : IDesignTimeDbContextFactory<AppDataContext>
    {
        public AppDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDataContext>();
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Kam\\Source\\OnionArchitecture\\App.Infrastructure.DataAccess\\App_Data\\CatalogueDatabase.mdf';Integrated Security=True");

            return new AppDataContext(builder.Options);
        }
    }
}
