using API.Contracts.Common;
using Application.Enums;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if (errors.Any(e => e.Code == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);
                apiError.StatusCode = 404;
                apiError.StatusPhrase = "Not Found";
                apiError.TimeStamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }

            apiError.StatusCode = 400;
            apiError.StatusPhrase = "Bad Request";
            apiError.TimeStamp = DateTime.Now;
            errors.ForEach(e => apiError.Errors.Add(e.Message));

            return StatusCode(400, apiError);
        }
    }
}
