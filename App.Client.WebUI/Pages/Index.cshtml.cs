using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace App.Client.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("OnGet() method was called on the Index page.");
        }
    }
}