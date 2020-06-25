//
// Optimiser.Blazor.Program
//

using GeneralComponents;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optimiser.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Logging.SetMinimumLevel(LogLevel.Information);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOptions();

            builder.Services.AddSingleton(
                new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
