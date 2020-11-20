using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [ValidateModel]
    // [ApiExceptionFilter]
    [Route("[controller]")]
    public class BaseApiController : Controller
    {
        [NonAction]
        protected IActionResult Success<T>(T data, string message) =>
            StatusCode(200, new ApiData<T>
            {
                Success = true,
                Data = data,
                Message = message
            });

        [NonAction]
        protected IActionResult BadRequest<T>(T data) => StatusCode(400, new ApiData<T> {Success = false, Data = data});

        [NonAction]
        protected IActionResult BadRequest<T>(T data, string message) => StatusCode(400,
            new ApiData<T> {Success = false, Data = data, Message = message});

        [NonAction]
        protected IActionResult Unauthorized<T>(T data) =>
            StatusCode(401, new ApiData<T> {Success = false, Data = data});

        [NonAction]
        protected IActionResult Forbidden<T>(T data) => StatusCode(403, new ApiData<T> {Success = false, Data = data});

        [NonAction]
        protected IActionResult NotFound<T>(T data) => StatusCode(404, new ApiData<T> {Success = false, Data = data});

        [NonAction]
        protected IActionResult Error(string message, string[] errors) => StatusCode(500,
            new ApiData<string[]> {Success = false, Data = errors, Message = message});
    }
}