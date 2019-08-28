using System;
using System.Collections.Generic;

//
//  2018-06-29  Mark Stega
//              Created
//
//  2019-01-29  Mark Stega
//              Changed CSE default for OptimiserUseLiveData to true
//

namespace GeneralComponents.SystemFramework
{
    public class ApplicationConfiguration
    {

        #region Data members

        private static readonly ApplicationConfiguration m_Instance = new ApplicationConfiguration();
        private static Dictionary<string, string> m_Dictionary = new Dictionary<string, string>();

        #endregion

        #region Ctor

        private ApplicationConfiguration()
        {
        }
        #endregion

        #region ApplicationConfiguration singleton instance

        public static ApplicationConfiguration pInstance
        {
            get { return m_Instance; }
        }

        #endregion

        #region Initialize

        private void Initialize(string p_FileContent, string p_CommandLine)
        {
            // First assign all properties that are not assigned in the CSE/SSE calls to constants
            pURI_WCF_CommunicationService = "http://localhost:9020/Optimiser.2012/CommunicationService";
            pURI_WCF_FileCleanupService = "http://localhost:9060/Optimiser.2012/FileCleanupService";
            pURI_WCF_LCIFileInterfaceService = "http://localhost:9050/Optimiser.2012/LCIFileInterfaceService";
            pURI_WCF_PATFileInterfaceService = "http://localhost:9010/Optimiser.2012/PATFileInterfaceService";
            pURI_WCF_PersistentStorageService = "http://localhost:9000/Optimiser.2012/PersistentStorageService";
            pURI_WCF_RIAOFileInterfaceService = "http://localhost:9070/Optimiser.2012/RIAOFileInterfaceService";
            pURI_WCF_ReportService = "http://localhost:9030/Optimiser.2012/ReportService";
            pURI_WCF_SystemMonitorService = "http://localhost:9040/Optimiser.2012/SystemMonitorService";

#if DEBUG || DEBUGALL
            pSQL_ConnectionString_Archive = "server=localhost\\SQLEXPRESS;database=Optimiser.2012.LBH.Archive;Trusted_Connection=True";
            pSQL_ConnectionString_Current = "server=localhost\\SQLEXPRESS;database=Optimiser.2012.LBH.Current;Trusted_Connection=True";
            pSQL_ConnectionString_Report = "server=localhost\\SQLEXPRESS;database=Optimiser.2012.LBH.Report;Trusted_Connection=True";
#endif

#if LBH
            pSQL_ConnectionString_Archive = "server=localhost\\SQLEXPRESS;database=Optimiser.2012.LBH.Archive;Trusted_Connection=True";
            pSQL_ConnectionString_Current = "server=localhost\\SQLEXPRESS;database=Optimiser.2012.LBH.Current;Trusted_Connection=True";
            pSQL_ConnectionString_Report = "server=localhost\\SQLEXPRESS;database=Optimiser.2012.LBH.Report;Trusted_Connection=True";
#endif

            try
            {
                pConfiguration_OptimiserUseLiveData = Convert.ToBoolean(Environment.GetEnvironmentVariable("OptimiserUseLiveData"));
            }
            catch
            {
                pConfiguration_OptimiserUseLiveData = false;
            }

            // Second override properties defined in p_FileContent

            // Third override properties deined in p_CommandLine

        }

        public void InitializeCSE(string p_FileContent, string p_CommandLine)
        {
            pURI_Rest_PersistentStorageService = "api/persistentstorage/";

            Initialize(p_FileContent, p_CommandLine);
        }

        public void InitializeSSE(string p_FileContent, string p_CommandLine)
        {
            pURI_Rest_PersistentStorageService = "https://localhost:44348/api/persistentstorage/";

            Initialize(p_FileContent, p_CommandLine);
        }

        #endregion

        #region Properties

        public string pSQL_ConnectionString_Archive { get; private set; }
        public string pSQL_ConnectionString_Current { get; private set; }
        public string pSQL_ConnectionString_Report { get; private set; }

        public string pURI_Rest_PersistentStorageService { get; private set; }

        public string pURI_WCF_CommunicationService { get; private set; }
        public string pURI_WCF_FileCleanupService { get; private set; }
        public string pURI_WCF_LCIFileInterfaceService { get; private set; }
        public string pURI_WCF_PATFileInterfaceService { get; private set; }
        public string pURI_WCF_PersistentStorageService { get; private set; }
        public string pURI_WCF_RIAOFileInterfaceService { get; private set; }
        public string pURI_WCF_ReportService { get; private set; }
        public string pURI_WCF_SystemMonitorService { get; private set; }

#if (DEBUG || DEBUGALL)
        public bool pConfiguration_OptimiserUseLiveData  { get; private set; }
#endif

#endregion
    }
}
