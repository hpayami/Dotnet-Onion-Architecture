using App.Domain.Entities;
using App.Domain.Interfaces;
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
            Products = await _catalogueUnitOfWork.ProductRepository.FindAllAsync(p => p.Category);
        }
    }
}
