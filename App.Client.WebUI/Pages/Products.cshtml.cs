using App.Core.Domain.Entities;
using App.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Client.WebUI.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService _productService;

        public IEnumerable<Product> Products { get; set; }

        public ProductsModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGetAsync(int? id)
        {
            Products = await _productService.GetProductsAsync(id);
        }
    }
}