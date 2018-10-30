using System.Collections.Generic;
using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts(int? categoryId);
    }
}
