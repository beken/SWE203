using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models {
    public class StoreDbContext : DbContext {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options) { }
        public DbSet<Product> Products => Set<Product>();
        
        //public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        
        
        //When the database is created, EF creates tables that have names the same as the DbSet property names. 

        //If you want to specify table names use the following code:
        /* 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Product");
            modelBuilder.Entity<ProductCategories>().ToTable("ProductCategory");
        }
        */
    }
}

