using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApp.Util.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PaymentApp.Controllers
{
    public class BaseController : Controller
    {
        ILogger logger;

        public BaseController(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("BaseController");
        }


        [NonAction]
        public async Task<ActionResult> ActionHandle(Func<Task<ActionResult>> action)
        {
            try
            {
                return await action.Invoke();
            }
            catch (AggregateException ae)
            {
                try
                {
                    ae.Handle(ex => { throw ex; });
                }
                catch (Exception ex)
                {
                    Log(ex);
                    return StatusCode(500, ex.Message);
                }

                return StatusCode(500, ae.Message);
            }
            catch (Exception ex)
            {
                Log(ex);
                return StatusCode(500, ex.Message);
            }
        }

        void Log(Exception ex)
        {
            if (ex is AppException applicaitonException)
            {
                logger.LogWarning(ex, $"Application exception - {applicaitonException.Message}");
            }
            else
            {
                logger.LogError(ex, "Unhandled exception");
            }
        }
    }
}