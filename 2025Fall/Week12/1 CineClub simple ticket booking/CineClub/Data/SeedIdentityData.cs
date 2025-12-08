using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CineClub.Data;

public static class SeedIdentityData
{
    private const string adminUser = "Admin";
    private const string adminPassword = "AdminPassword123$";
    private const string regularUser = "User";
    private const string regularPassword = "UserPassword123$";
    private const string adminRole = "Admin";
    private const string userRole = "User";
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        CineIdentityDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CineIdentityDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        var scope = app.ApplicationServices.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


        if (!roleManager.RoleExistsAsync(adminRole).Result)
        {
            roleManager.CreateAsync(new IdentityRole(adminRole)).Wait();
        }

        if (!roleManager.RoleExistsAsync(userRole).Result)
        {
            roleManager.CreateAsync(new IdentityRole(userRole)).Wait();
        }

        var admin = userManager.FindByNameAsync(adminUser).Result;
        if (admin == null)
        {
            var newAdmin = new IdentityUser
            {
                UserName = adminUser,
                Email = "admin@cineclub.com",
                EmailConfirmed = true,
                PhoneNumber = "02641234567"
            };

            var result = userManager.CreateAsync(newAdmin, adminPassword).Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(newAdmin, adminRole).Wait();
            }
        }

        var regular = userManager.FindByNameAsync(regularUser).Result;
        if (regular == null)
        {
            var newUser = new IdentityUser
            {
                UserName = regularUser,
                Email = "user@cineclub.com",
                EmailConfirmed = true,
                PhoneNumber = "02647654321"
            };

            var result = userManager.CreateAsync(newUser, regularPassword).Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(newUser, userRole).Wait();
            }
        }
    }
}