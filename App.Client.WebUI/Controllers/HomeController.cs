using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Client.WebUI.Models;

using App.Domain.ServicesInterface.Framework;

namespace App.Client.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetCategories());
        }

        public IActionResult Products(int id)
        {
            return View(_productService.GetProducts(id));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
