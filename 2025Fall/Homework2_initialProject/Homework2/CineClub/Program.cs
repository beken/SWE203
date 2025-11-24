using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CineClub.Data;
using CineClub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CineDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<CineIdentityDbContext>(opts => opts.UseSqlite(
    builder.Configuration.GetConnectionString("IdentityDbConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CineIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserHelperService, UserHelperService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1; 
    options.Password.RequiredUniqueChars = 0;

    //options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

SeedIdentityData.EnsurePopulated(app);
SeedCineData.EnsurePopulated(app);

app.Run();
