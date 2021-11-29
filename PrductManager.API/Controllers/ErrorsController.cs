using Microsoft.AspNetCore.Mvc;
using System.Net;
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
