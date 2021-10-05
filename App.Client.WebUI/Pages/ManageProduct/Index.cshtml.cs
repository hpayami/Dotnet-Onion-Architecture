using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages.ManageProduct
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public IEnumerable<Product> Products { get; set; }

        public IndexModel(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public async Task OnGetAsync()
        {
            Products = await _catalogueUnitOfWork.ProductRepository.FindAllIncludeAsync(p => p.Category);
        }
    }
}