using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace middleware;

public class LanguageFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {

        if (context.HttpContext.Request.Headers["Language"] != "uz" && context.HttpContext.Request.Headers["Language"] != "en")
        {
            /*context.Result = new JsonResult(new { ErrorMessage = "Write en or uz " });*/
            // throw new NotSupportedException("ErrorMessage = \"Write en or uz \"");
            throw new Exception("ErrorMessage = \"Write en or uz \"");

        }

        LanguageCulture.Culture = context.HttpContext.Request.Headers["Language"];
       
    }
}
