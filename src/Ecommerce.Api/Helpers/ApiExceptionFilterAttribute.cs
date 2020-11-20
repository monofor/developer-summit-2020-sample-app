using System.Net;
using System.Threading.Tasks;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.Api
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            context.Exception = null;
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new ApiData<object>()
            {
                Message = "Internal server error. Please contact your system administrator.",
            });

            await base.OnExceptionAsync(context);
        }
    }
}