using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Client.WebUI.Pages.BulkInsert
{
    public class ViewDataModel : PageModel
    {
        private IFileService _fileService;

        public IEnumerable<BulkImport> BulkImports { get; set; } = new List<BulkImport>();

        public ViewDataModel(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task OnGetAsync()
        {
            BulkImports = await _fileService.FindAllAsync();
        }
    }
}
