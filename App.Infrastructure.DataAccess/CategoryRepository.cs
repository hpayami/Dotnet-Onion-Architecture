using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.DataAccess.DataContext;
using App.Infrastructure.DataAccess.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess
{
    public class CategoryRepository : ReadWriteEFRespository<int, Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoryWithProductsAsync()
        {
            return await FindAllIncludeAsync(p => p.Products);
            
        }
    }
}
