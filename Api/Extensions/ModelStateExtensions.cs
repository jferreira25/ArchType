using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Base.Admin.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorsMessages(this ModelStateDictionary modelState)
        {
            return modelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
        }
    }
}
