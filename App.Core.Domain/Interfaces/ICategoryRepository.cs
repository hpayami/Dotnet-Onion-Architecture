using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces
{
    public interface ICategoryRepository : IReadWriteRepository<int, Category>
    {
        Task<IEnumerable<Category>> GetCategoryWithProductsAsync();
    }
}
