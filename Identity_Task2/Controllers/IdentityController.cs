using Identity.Task2;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity_Task2.Controllers;
[ApiController]
[Route("/api/[controller]/n")]

public class IdentityController : Controller
{
    private readonly JsonService _jsonService;

    public IdentityController(JsonService jsonService)
    {
        _jsonService = jsonService;
    }

    [HttpGet]
    public IActionResult GetEkuk(int n)
    {
      
    }
    [HttpPost]
    public IActionResult Post(User user)
    {
        var key = Guid.NewGuid().ToString();
        _jsonService.Tojon(key,user);
        return Ok(key);
    }

    [HttpGet("GetForUser")]
    [TypeFilter(typeof(AuthAtribute), Arguments = new object[] { "user" })]
    public IActionResult GetForUser()
    {
        var name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
        return Ok(name.Value);
    }

    [HttpGet("GetForAdmin")]
    [TypeFilter(typeof(AuthAtribute), Arguments = new object[] { "admin" })]
    public IActionResult GetForAdmin()
    {
        var name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
        return Ok(name.Value);
    }
    [HttpGet("GetForAdminandUser")]
    [Role("admin,user")]
    public IActionResult GetForAdminandUser()
    {
        var name = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
        return Ok(name.Value);
    }

}
