using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models {
public static class SeedData {

    //IApplicationBuilder interface used to register middleware components to handle HTTP requests
    public static void EnsurePopulated(IApplicationBuilder app) {
        StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
        
        if (context.Database.GetPendingMigrations().Any()) {
            context.Database.Migrate();
        }
        //If there are no objects in the database, then the database is populated using a collection of Product objects 
        if (!context.Products.Any()) {
            context.Products.AddRange(
                new Product {
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Price = 15000, 
                    Category = "Watersports"},
                    
                new Product {
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Price = 1000,
                    Category = "Watersports"}
                    );
                context.SaveChanges();
            }
        }
    }
}
