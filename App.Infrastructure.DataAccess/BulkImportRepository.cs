using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using App.Infrastructure.DataAccess.Framework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess
{
    public class BulkImportRepository : ReadWriteEFRespository<int, BulkImport>, IBulkImportRepository
    {
        public BulkImportRepository(DbContext context) : base(context)
        {
        }

        public async Task RemoveAllRecords()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [BulkImports]");
        }
    }
}