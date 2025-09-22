using Microsoft.EntityFrameworkCore;
using SportsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


//session configuration
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt => {
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true; //ensure cookies cannot be accessed by client side scripts
    opt.Cookie.IsEssential = true; //indicates if cookie is essential for the application to function correctly
}
);

//db configurations
builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlite(
        builder.Configuration["ConnectionStrings:SportsStoreDBConnection"]);
});

builder.Services.AddDbContext<AppIdentityDbContext>(opts => 
    opts.UseSqlite(
        builder.Configuration["ConnectionStrings:IdentityDBConnection"]));


//identity configuration
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();

//Identity created default cookies when we call AddIdentity. Let's configure default AccessDenied, Login, and Logout paths:

builder.Services.ConfigureApplicationCookie(opt => {
    opt.AccessDeniedPath = "/Home/AccessDenied"; 
    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout"; 
    opt.Cookie.HttpOnly = true; //ensure cookies cannot be accessed by client side scripts
    opt.ExpireTimeSpan = TimeSpan.FromDays(14); //persistent cookie
    opt.SlidingExpiration = true; //reset the expiration time if the user is active
});




var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseAuthentication();
app.UseAuthorization();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);


app.Run();
