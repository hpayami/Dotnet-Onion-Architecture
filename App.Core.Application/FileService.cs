using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application
{
    public class FileService : IFileService
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public FileService(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public async Task ImportFileAsync(string fileName)
        {
            string line;

            await _catalogueUnitOfWork.BulkImportRepository.RemoveAllRecords();

            // Read the file and import into the databse
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                try
                {
                    while ((line = await streamReader.ReadLineAsync()) != null)
                    {
                        _catalogueUnitOfWork.BulkImportRepository.Add(new BulkImport()
                        {
                            Filename = Path.GetFileName(fileName),
                            Data = line,
                            CreatedOn = DateTime.UtcNow
                        });
                    }

                    await _catalogueUnitOfWork.CommitAsync();
                }
                finally
                {
                    streamReader.Close();
                }
            }
        }

        public async Task<IEnumerable<BulkImport>> FindAllAsync()
        {
            return await _catalogueUnitOfWork.BulkImportRepository.FindAllAsync();
        }
    }
}
