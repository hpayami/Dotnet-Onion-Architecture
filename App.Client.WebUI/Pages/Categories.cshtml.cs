using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly IProductService _productService;

        public IEnumerable<Category> Categories { get; set; }

        public CategoriesModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _productService.GetCategoriesAsync();
        }
    }
}