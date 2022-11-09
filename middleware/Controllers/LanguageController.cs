using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace middleware.Controllers;
[ApiController]
[Route("api/[controller]")]
[LanguageFilter] // ustunligi xato bolsa kirmay tez qaytishida , agar to'gri bolsa bir xil ish bajariladi. 
public class LanguageController : ControllerBase // base without view supported
{
    private List<string> _uzdata = new List<string>() { "malumot1", "malumot2" };
    private List<string> _endata = new List<string>() { "information1", "information2" };
    [HttpGet]

    public IActionResult GetData()
    {
        //var num = int.Parse("a"); //200 qaytaropdi

        if (LanguageCulture.Culture == "uz")
            return Ok(_uzdata);

        return Ok(_endata);
    }
}
