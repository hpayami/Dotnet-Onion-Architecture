using App.Domain.Entities;
using App.Domain.Interfaces.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICategoryRepository : IReadOnlyRepository<int, Category>
    {
        Task<IEnumerable<Category>> GetCategoryWithProductsAsync();
    }
}
