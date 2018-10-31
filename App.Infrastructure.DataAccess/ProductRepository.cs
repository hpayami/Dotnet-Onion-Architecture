using Microsoft.EntityFrameworkCore;

using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.DataAccess.Framework;

namespace App.Infrastructure.DataAccess
{
    public class ProductRepository : ReadOnlyEFRespository<int, Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
