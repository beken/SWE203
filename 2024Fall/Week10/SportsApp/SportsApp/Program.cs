using Microsoft.EntityFrameworkCore;
using SportsApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

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

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseAuthorization();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
