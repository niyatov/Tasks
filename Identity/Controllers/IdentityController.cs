using Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Identity;
using System.Security.Claims;

namespace Identity.Controllers;
[Route("/api/Controller")]
[ApiController]

public class IdentityController : Controller
{
    private readonly AppDbContext _context;

    public IdentityController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Post(string name, string password)
    {
        var user = new User
        {
            Name = name,
            Password = password,
            Key = Guid.NewGuid().ToString(),
        };
        _context.Add(user);
        _context.SaveChanges();
        return Ok(user.Key);
    }


    /*   [HttpGet("private")]
      public IActionResult GetPrivate()
      {
          if (!IsAuthorize(out var key))
              return Unauthorized();
          return Ok("private");
      }
      // [Filter] if it used injection, this thing is red until you overwrite it as under thing
      [HttpGet("privateWithAttribute")]
      [TypeFilter(typeof(FilterAttribute))]  // it used to get context from container
      public IActionResult GetPrivatewithAttribute()
      {
          return Ok("private");
      }*/




    private bool IsAuthorize(out string key)
    {
        key = "";
        var istrue = HttpContext.Request.Headers.ContainsKey("key");
        if (!istrue)
            return false;
        var b = HttpContext.Request.Headers["key"].ToString();
        key = b;
        if (!_context.Users.Any(x => x.Key == b))
            return false;
        return true;
    }
}
