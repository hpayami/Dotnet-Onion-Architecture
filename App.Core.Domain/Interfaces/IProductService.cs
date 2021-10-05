using App.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<IEnumerable<Product>> GetProductsAsync(int? categoryId);

        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();

        Task<Category> AddCategory(string name);
    }
}