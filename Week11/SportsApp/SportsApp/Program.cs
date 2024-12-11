using Microsoft.EntityFrameworkCore;
using SportsApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
}
);


builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlite(
        builder.Configuration["ConnectionStrings:SportsStoreDBConnection"]);
});

builder.Services.AddDbContext<AppIdentityDbContext>(opts => 
    opts.UseSqlite(
        builder.Configuration["ConnectionStrings:IdentityDBConnection"]));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();



var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseAuthorization();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
