using System.Collections.Generic;
using App.Domain.Entities;

namespace App.Domain.ServicesInterface.Framework
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts(int? categoryId);
    }
}
