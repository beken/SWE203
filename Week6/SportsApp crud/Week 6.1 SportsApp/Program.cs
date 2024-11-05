using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlite(
        builder.Configuration["ConnectionStrings:SportsStoreDBConnection"]);
});


var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
