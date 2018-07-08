using App.Domain.Entities;

namespace App.Domain.RepoInterfaces
{
    public interface IProductRepository : IReadonlyRespository<int, Product>
    {
    }
}
