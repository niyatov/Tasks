using Identityy;
using Identityy.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source = Identity.db"));

// builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
// User IdentityUserdan implement qilgan shuning uchun o'rniga qo'ysak bo'ladi.

builder.Services.AddIdentity<User, UserRole>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<AppDbContext>();

// 1 - Addidentity<> generic u yordamida user va uni role ni container ga qo'shamiz,
// Identity,IdentityRole ni o'rniga undan implement qilingan class ni bemalol yoza olamiz,
// agar biz identityUser biror ortiqcha chatid shunga o'xshagan narsa qo'shmoqchi bo'lsak
// implement qilib so'ng shu yerga o'rniga yozib qoyamiz IdentityDbContext<User, .. > deb ham
// o'zgaradi. Passwordga required yozish mumkin options yordamida.
// 2 - AddEntityFrameworkStores<> ga database ni nomini yozamiz.
// 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Identity Authentication uchun foydalanadi. o'zini tayyor classlari bor. Userni saqlaydi
// token berib cookie siga yozib qoyadi. biror databasega IdentityDbContext ni qo'shib qoysak 
// yetarli