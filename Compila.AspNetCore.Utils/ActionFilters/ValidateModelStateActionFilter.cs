using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Compila.AspNetCore.Utils.ActionFilters
{
    public class ValidateModelStateActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList();

                var messageResult = new ActionFilterMessage() { Message = "Bad Request", Errors = errors };

                context.Result = new JsonResult(messageResult)
                {
                    StatusCode = 400
                };
            }
            else
            {
                await next();
            }
        }
    }
}
