using Microsoft.EntityFrameworkCore;

using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using App.Infrastructure.DataAccess.Framework;

namespace App.Infrastructure.DataAccess
{
    public class ProductRepository : ReadWriteEFRespository<int, Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
