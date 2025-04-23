using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HW2_RestfulApi.Attributes;

public class AuthorizeAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isAuthenticated = context.HttpContext.Request.Headers["X-User"] == "admin";
        if (!isAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        await next();
    }
}