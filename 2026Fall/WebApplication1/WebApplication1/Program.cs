var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //enables MVC pattern

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
