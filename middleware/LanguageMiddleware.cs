using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace middleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public  Task Invoke(HttpContext httpContext)
    {
        if (!httpContext.Request.Headers.ContainsKey("Language"))
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            //return httpContext.Response.WriteAsync("Language not Found");
            throw new Exception("Language not Found");

        }
        return _next(httpContext);  
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class LanguageMiddlewareExtensions
{
    public static IApplicationBuilder UseLanguageMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LanguageMiddleware>();
    }
}
