using Microsoft.EntityFrameworkCore;

using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.DataAccess.Framework;

namespace App.Infrastructure.DataAccess
{
    public class CategoryRepository : EFReadonlyRepository<int, Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
