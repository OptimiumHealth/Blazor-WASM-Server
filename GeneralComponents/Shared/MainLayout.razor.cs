using GeneralComponents.SystemFramework;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GeneralComponents.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject] ILogger<LoggingFramework> m_Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            m_Logger.LogDebug("");
            m_Logger.LogDebug("MainLayout OnInitAsync()");
        }
    }
}
