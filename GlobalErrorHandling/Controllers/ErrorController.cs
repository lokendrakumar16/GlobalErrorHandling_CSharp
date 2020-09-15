using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")] 
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var statusCode = exception.Error.GetType().Name switch
            {
                "ArgumentException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.ServiceUnavailable
            };

            return Problem(detail:exception.Error.Message, statusCode : (int) statusCode );
        }
    }
}
