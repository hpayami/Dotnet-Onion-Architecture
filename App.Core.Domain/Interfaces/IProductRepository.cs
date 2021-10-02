using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces.Framework;

namespace App.Core.Domain.Interfaces
{
    public interface IProductRepository : IReadWriteRepository<int, Product>
    {
    }
}
