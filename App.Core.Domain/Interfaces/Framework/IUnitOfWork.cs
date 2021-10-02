using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces.Framework
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
