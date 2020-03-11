//
// Optimiser.Blazor.Program
//

using GeneralComponents;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;

namespace Optimiser.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddOptions();

            builder.Services.AddBaseAddressHttpClient();

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}
