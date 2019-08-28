using GeneralComponents.SystemFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//
//  2018-06-11  Mark Stega
//              Created
//

namespace Optimiser.Web.Controllers
{
    //    [Produces("application/json")]
    [Route("api/[controller]")]
    //    [ApiController]
    public class PersistentStorageController : ControllerBase
    {
        private readonly ILogger<LoggingFramework> m_Logger;

        public PersistentStorageController(ILogger<LoggingFramework> p_Logger)
        {
            m_Logger = p_Logger;
        }


    }
}
