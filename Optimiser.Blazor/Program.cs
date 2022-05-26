//
// Optimiser.Blazor.Program
//

using System.Threading.Tasks;

using GeneralComponents;
using GeneralComponents.Infrastructure.ClientServices;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Optimiser.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            ClientServices.Inject(
                builder.HostEnvironment.BaseAddress,
                builder.Services);

            await builder.Build().RunAsync();
        }
    }
}
