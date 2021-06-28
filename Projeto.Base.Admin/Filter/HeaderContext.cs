
using Projeto.Base.Admin.Core;
using Projeto.Base.Admin.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Projeto.Base.CrossCutting.Configuration.Exceptions;

namespace Projeto.Base.Admin.Filter
{
    public class HeaderContext : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var token = context.HttpContext.GetAuthorizationTokenFromRequest();

                if (!TokenValidator.Validate(token))
                    throw new ApiHttpCustomException("Unauthorized", System.Net.HttpStatusCode.Unauthorized);

            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();
                Console.WriteLine($"Erro na obteção de header para o context. {ex.Message}");
            }

            base.OnActionExecuting(context);
        }

    }
}
