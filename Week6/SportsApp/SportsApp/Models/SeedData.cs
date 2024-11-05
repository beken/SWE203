using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models
{
    public static class SeedData{
        public static void EnsurePopulated(IApplicationBuilder app){
            SportsStoreDBContext context = app.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<SportsStoreDBContext>();

            if(context.Database.GetPendingMigrations().Any()){
                context.Database.Migrate();
            }

            if(!context.Products.Any()){
                context.Products.AddRange(
                    new Product {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Price = 15000,
                        Category = "Watersports"
                    },
                    new Product {
                        Name = "Lifejacket",
                        Description = "Fashionable",
                        Price = 1000,
                        Category = "Watersports"
                    }
                );
            }
        }
        

    }

}