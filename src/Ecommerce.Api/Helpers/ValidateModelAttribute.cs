using System.Linq;
using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.Api
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Select(m => new
                {
                    m.Key,
                    Errors = m.Value.Errors.Select(x => x.ErrorMessage)
                }).ToList();

                context.Result = new BadRequestObjectResult(new ApiData<object>()
                {
                    Message = "Form data not validated.",
                    Data = errors
                });
            }

            base.OnActionExecuting(context);
        }
    }
}