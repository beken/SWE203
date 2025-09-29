var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/abc", () => "Hello abc!");
app.MapDefaultControllerRoute();

app.Run();
