using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages.ManageProduct
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public DeleteModel(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _catalogueUnitOfWork.ProductRepository.FindAsync((int)id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _catalogueUnitOfWork.ProductRepository.FindAsync((int)id);

            if (Product != null)
            {
                await _catalogueUnitOfWork.ProductRepository.RemoveAsync(Product);
                await _catalogueUnitOfWork.CommitAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
