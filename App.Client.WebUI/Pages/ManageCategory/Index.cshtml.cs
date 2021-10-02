using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages.ManageCategory
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }        

        public async Task OnGetAsync()
        {
            Categories = await _catalogueUnitOfWork.CategoryRepository.FindAllAsync();
        }
    }
}
