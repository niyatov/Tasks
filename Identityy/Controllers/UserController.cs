using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identityy.Controllers;
[ApiController]
[Route("/api/[controller]")]

public class UserController : ControllerBase
{
    // private readonly UserManager<IdentityUser> _userManager;

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    //  - UserManager<> generic IdentityUser yoki uni implement qilgan classlarni qabul
    // qiladi. User ni database ga qo'shadi  (CreateAsync), olib keladi .. user bilan ishlaydi
    //  - SignInManager<> generic IdentityUser yoki uni implement qilgan classlarni qabul
    // qiladi.Cookie ga yozadi (SignInAsync) methodi yordamida
    public UserController(UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUser model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("ModelState is not valid");
        }
        var user = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            Password = model.Password,
        };
        var createUser = await _userManager.CreateAsync(user, model.Password);
        if (!createUser.Succeeded)
        {
            return BadRequest("not creating user");
        }
        await _signInManager.SignInAsync(user, isPersistent: false);

        return Ok("Created user and added into cookies");
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInUser model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("ModelState is not valid");
        }

        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user == null)
            return BadRequest("not found user");
        if (user.Password != model.Password)
            return BadRequest("Password is incorrect");
        await _signInManager.SignInAsync(user, isPersistent: false);
        return Ok("added into cookies");
    }

    [Authorize]
    [HttpGet("Get")]
    public IActionResult Get()
    {
        return Ok("data");
    }
}
