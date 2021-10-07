using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces.Framework
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}