using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages.ManageProduct
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public IEnumerable<SelectListItem> CategoryList = new List<SelectListItem>();

        public CreateModel(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public async Task LoadLookupsAsync()
        {
            CategoryList = (await _catalogueUnitOfWork.CategoryRepository.FindAllAsync())
                           .Select(p => new SelectListItem() 
                           { 
                               Value = p.CategoryId.ToString(), 
                               Text = p.CategoryName 
                           });
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadLookupsAsync();

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return Page();
            }

            await _catalogueUnitOfWork.ProductRepository.AddAsync(Product);
            await _catalogueUnitOfWork.CommitAsync();

            return RedirectToPage("./Index");
        }
    }
}
