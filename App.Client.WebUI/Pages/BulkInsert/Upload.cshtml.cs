using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Client.WebUI.Pages.BulkInsert
{
    public class UploadModel : PageModel
    {
        private readonly AppSettings _appSettings;
        private readonly IFileService _fileService;

        [BindProperty]
        [Required]
        public IFormFile UploadedFile { get; set; }

        public string Message { get; set; }

        public UploadModel(AppSettings appSettings, IFileService fileService)
        {
            _appSettings = appSettings;
            _fileService = fileService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (UploadedFile != null && UploadedFile.Length > 0)
            {
                if (Path.GetExtension(UploadedFile.FileName).ToLower() == ".csv")
                {
                    // create the directory if it doesn't exists, before saving
                    if (!Directory.Exists(_appSettings.FileUpload.DestinationPath))
                        Directory.CreateDirectory(_appSettings.FileUpload.DestinationPath);

                    var filePath = Path.Combine(_appSettings.FileUpload.DestinationPath, UploadedFile.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await UploadedFile.CopyToAsync(fileStream);
                    }

                    await _fileService.ImportFileAsync(filePath);
                }
                else
                {
                    Message = $"Cannot upload '{UploadedFile.FileName}', only .csv files accepted";
                    UploadedFile = null; 
                }
            }
        }
    }
}
