using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Helpers;

namespace API.Attributes;

public class CustomAuthorizeAttribute : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Check if user is authenticated
        var apikey = context.HttpContext.Request.Headers["x-api-key"].ToString();
        var httpContext = context.HttpContext;

        var dbContext = httpContext.RequestServices.GetService(typeof(IApplicationDBContext)) as IApplicationDBContext;
        var user = dbContext.Set<User>().FirstOrDefault(_ => _.APIKey == apikey);
        if (user == null)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Logic after the action executes (if needed)
    }
}
