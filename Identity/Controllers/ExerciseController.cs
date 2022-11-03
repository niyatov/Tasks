using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;
[Route("/api/ExerciseController/son1/son2")]
[ApiController]
[TypeFilter(typeof(FilterAttribute))]
public class ExerciseController : Controller
{
    [HttpGet]
    public IActionResult Index(int son1,int son2)
    {
        
        int s = 0, b, s1 = 0;
        int n = son1;
        while (n != 0)
        {
            b = n / (int)(Math.Pow(10, (int)Math.Log10(n)));
            for (int i = 1; i <= (int)(Math.Log10(n)); i++)
                s1 += (int)((Math.Pow(10, i - 2)) * (9 * i + 1));
            s1 *= b;
            if (b >= son2 + 1) s1 += ((int)Math.Pow(10, (int)Math.Log10(n)));
            else if (b >= son2) s1 += n - (int)Math.Pow(10, (int)Math.Log10(n)) * b + 1;
            s += s1; s1 = 0;
            n -= (int)Math.Pow(10, (int)Math.Log10(n)) * b;
        }
        return Ok(s);
    }
}
