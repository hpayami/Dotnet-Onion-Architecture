using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages.ManageCategory
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogueUnitOfWork _catalogueUnitOfWork;

        public CreateModel(ICatalogueUnitOfWork catalogueUnitOfWork)
        {
            _catalogueUnitOfWork = catalogueUnitOfWork;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _catalogueUnitOfWork.CategoryRepository.AddAsync(Category);
            await _catalogueUnitOfWork.CommitAsync();
            
            return RedirectToPage("./Index");
        }
    }
}
