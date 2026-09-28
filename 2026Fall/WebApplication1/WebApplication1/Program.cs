var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //enables MVC pattern

var app = builder.Build();

app.MapDefaultControllerRoute(); //adds default route (home/index) for controllers

//app.MapGet("/", () => "Hello World!"); //adds a default route for the root URL
//app.MapGet("/abc", () => "Hello ABC!"); //adds a default route for the /abc URL

app.Run();
