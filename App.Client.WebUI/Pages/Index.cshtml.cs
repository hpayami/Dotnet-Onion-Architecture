using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace App.Client.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Product> Products { get; set; }

        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Categories = _productService.GetCategories();

            Products = _productService.GetProducts(1);
        }
    }
}
