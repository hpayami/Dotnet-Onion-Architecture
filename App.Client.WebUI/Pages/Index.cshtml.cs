using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Category> CategoriesWithProducts { get; set; }

        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _productService.GetCategoriesAsync();

            Products = await _productService.GetProductsAsync(1);

            CategoriesWithProducts = await _productService.GetCategoriesWithProductsAsync();
        }
    }
}

