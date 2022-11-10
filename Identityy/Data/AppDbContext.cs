using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identityy.Data
{
    public class AppDbContext : IdentityDbContext<User,UserRole,long>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }
    }
}
//  IdentityDbContext ichida tayyor DbSetlar bor shunchaki biror databasega qo'shish kerak . <IdentityUser,IdentityRole,string>
// shart emas .