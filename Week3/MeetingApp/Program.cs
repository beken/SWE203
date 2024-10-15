var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();

app.Run();
