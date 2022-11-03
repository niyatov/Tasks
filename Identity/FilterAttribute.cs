using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Identity.Data;
namespace Identity;

public class FilterAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _context;

    public FilterAttribute(AppDbContext context)
    {
        _context = context;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {

        if (!context.HttpContext.Request.Headers.ContainsKey("key"))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var key = context.HttpContext.Request.Headers["key"].ToString();
        
        if (!_context.Users.Any(x => x.Key == key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
    }
}
