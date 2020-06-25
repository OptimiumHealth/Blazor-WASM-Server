using System.Runtime.InteropServices;

namespace GeneralComponents.Views
{
    public partial class AboutView
    {
#if DEBUG
        private string pMode { get; set; } = "debug";
#else
        private string pMode { get; set; } = "release";
#endif

        private string pRuntime { get; set; }

        public AboutView()
        {
            pRuntime = RuntimeInformation.FrameworkDescription.ToString();
        }
    }
}
