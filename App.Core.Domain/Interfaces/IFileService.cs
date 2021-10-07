using App.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Domain.Interfaces
{
    public interface IFileService
    {
        Task ImportFileAsync(string fileName);
        Task<IEnumerable<BulkImport>> FindAllAsync();
    }
}