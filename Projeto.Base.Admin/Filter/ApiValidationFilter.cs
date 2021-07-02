
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projeto.Base.Admin.Extensions;
namespace Projeto.Base.Admin.Filter
{
    public class ApiValidationFilter : IActionFilter
    {
      
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.GetErrorsMessages();
                
                context.Result = new JsonResult(new { notifications= errors }) { StatusCode = 400 };

            }
        }
    }
}

