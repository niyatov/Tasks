using Microsoft.AspNetCore.Identity;

namespace Identityy;

/*public class User : IdentityUser
{  
    public string Password { get; set; }
}*/

// endi IdentityUser o'rniga hamma joyda user yozib chiqishimiz mumkin

public class User : IdentityUser<long>
{
    public string Password { get; set; }
}

// Id ni string dan long ga o'tkazish uchun User va UserRole niki .
// ikkalisi bir typeda bo'lishi majburiy