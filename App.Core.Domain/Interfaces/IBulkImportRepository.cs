using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces.Framework;
using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces
{
    public interface IBulkImportRepository : IReadWriteRepository<int, BulkImport>
    {
        public Task RemoveAllRecords();
    }
}