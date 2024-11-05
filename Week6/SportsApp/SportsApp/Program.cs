using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SportsStoreDBContext>(opts => {
    opts.UseSqlite(builder.Configuration["ConnectionStrings:database"]);
});

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();
SeedData.EnsurePopulated(app);
app.Run();
