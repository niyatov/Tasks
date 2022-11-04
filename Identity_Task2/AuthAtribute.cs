using Identity_Task2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Identity.Task2;

public class AuthAtribute : ActionFilterAttribute
{
    private readonly JsonService _jsonService;
    private string[] Roles;
    public AuthAtribute (JsonService jsonService, string roles)
    {
        _jsonService = jsonService;
        Roles = roles.Split(',').ToArray();  
    }
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(!context.HttpContext.Request.Headers.ContainsKey("key"))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var key = context.HttpContext.Request.Headers["key"];
        var users = _jsonService.Fromjson();
        
        if (!users.Any(x => x.Key == key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var user = users.FirstOrDefault(users => users.Key == key);
        var value = user.Value; 
     
        
        if (!(Roles.Any(x=>x.Equals(value.Role)) || Roles[0].Equals("")))
        {
            context.Result = new JsonResult("Forbitted");
            return;
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, value.Name),
            new Claim(ClaimTypes.MobilePhone,value.PhoneNumber),
            new Claim(ClaimTypes.Role, value.Role),
        };

        var entity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(entity);
        context.HttpContext.User = principal;
    }
}
