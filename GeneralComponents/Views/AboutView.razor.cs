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

        private string pOSArchitecture { get; set; }
        private string pOSDescription { get; set; }
        private string pRuntime { get; set; }
        private string pVersion { get; set; }

        public AboutView()
        {
            pOSArchitecture = RuntimeInformation.OSArchitecture.ToString();
            pOSDescription = RuntimeInformation.OSDescription.ToString();
            pRuntime = RuntimeInformation.FrameworkDescription.ToString();
            pVersion = "Version 2022-05-20";
        }
    }
}
