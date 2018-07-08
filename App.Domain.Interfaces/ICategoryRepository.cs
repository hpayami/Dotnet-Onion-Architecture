using App.Domain.Entities;

namespace App.Domain.RepoInterfaces
{
    public interface ICategoryRepository : IReadonlyRespository<int, Category>
    {
    }
}
