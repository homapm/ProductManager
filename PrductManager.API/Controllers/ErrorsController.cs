using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace ProductManager.API.Controllers
{
    public class ErrorsController : Controller
    {
        [HttpGet]
        [Route("/errors")]
        public IActionResult HandleErrors()
        {
            var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var responseStatusCode = contextException.Error.GetType().Name switch
            {
                "NullReferenceException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.ServiceUnavailable
            };

            return Problem(detail: contextException.Error.Message, statusCode: (int)responseStatusCode);

        }
    }
}
