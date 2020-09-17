using System.Threading.Tasks;

namespace App.Domain.Interfaces.Framework
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
