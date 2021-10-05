using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(App.Client.WebUI.Areas.Identity.IdentityHostingStartup))]

namespace App.Client.WebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}