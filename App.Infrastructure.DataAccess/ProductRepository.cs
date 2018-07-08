using Microsoft.EntityFrameworkCore;

using App.Domain.Entities;
using App.Domain.RepoInterfaces;
using App.Infrastructure.DataAccess.Framework;

namespace App.Infrastructure.DataAccess
{
    public class ProductRepository : EFReadonlyRepository<int, Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
