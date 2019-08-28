//
//  Optimiser.Blazor.Startup
//
//  2019-04-18  Mark Stega
//              Created
//

using Blazor.Extensions.Logging;
using GeneralComponents.SystemFramework;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Optimiser.Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
             // Initialize defaults
            ApplicationConfiguration.pInstance.InitializeCSE("", "");

           services.AddLogging(builder => builder
                .AddBrowserConsole() // Add Blazor.Extensions.Logging.BrowserConsoleLogger
            );
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<GeneralComponents.App>("app");
        }
    }
}
