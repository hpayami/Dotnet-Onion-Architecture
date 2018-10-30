using App.Domain.Entities;
using App.Domain.Interfaces.Framework;

namespace App.Domain.Interfaces
{
    public interface IProductRepository : IReadonlyRespository<int, Product>
    {
    }
}
