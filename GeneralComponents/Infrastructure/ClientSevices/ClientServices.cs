using System;
using System.Net.Http;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GeneralComponents.Infrastructure.ClientServices
{
    public static class ClientServices
    {
        private static ILogger<string> pLogger { get; set; } = null;

        public static void Inject(string baseUri, IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUri) });
        }
    }
}
