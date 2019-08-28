using GeneralComponents.GCButton;
using GeneralComponents.SystemFramework;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

//
//  2018-07-09  Mark Stega
//              Created
//

namespace GeneralComponents.ORManager
{
    public class ORManagerBase : ComponentBase
    {
        [Inject] protected ILogger<LoggingFramework> pLogger { get; set; }

        public ORManagerBase()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            pLogger.LogDebug("ORManagerView OnInitAsync() entry");

//            pApplicationState.OnORManagerDataChange += ORManagerData_OnChange;

            StateHasChanged();
            pLogger.LogDebug("ORManagerView OnInitAsync() completion");
        }

    }
}
