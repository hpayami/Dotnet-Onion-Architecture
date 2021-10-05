using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages.ManageProduct
{
    public class EditModel : PageModel
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public IEnumerable<SelectListItem> CategoryList = new List<SelectListItem>();

        [BindProperty]
        public Product Product { get; set; }

        public EditModel(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public async Task LoadLookupsAsync(int selectedId)
        {
            CategoryList = (await _catalogueUnitOfWork.CategoryRepository.FindAllAsync())
                           .Select(p => new SelectListItem()
                           {
                               Value = p.CategoryId.ToString(),
                               Text = p.CategoryName,
                               Selected = p.CategoryId == selectedId
                           });
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _catalogueUnitOfWork.ProductRepository.FindAsync((int)id);

            await LoadLookupsAsync(Product.CategoryId);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync(Product.CategoryId);
                return Page();
            }

            _catalogueUnitOfWork.ProductRepository.Update(Product);
            await _catalogueUnitOfWork.CommitAsync();

            return RedirectToPage("./Index");
        }
    }
}