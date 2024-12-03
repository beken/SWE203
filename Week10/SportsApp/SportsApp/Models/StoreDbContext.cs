using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models {
    public class StoreDbContext : DbContext {
        
        //constructor sets up the database options
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options) { }
        
        //When the database is created, EF creates tables that have names the same as the DbSet property names. 
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<ProductReview> ProductReviews => Set<ProductReview>();


        
        //OnModelCreating method contains the configuration information for the EF core

        //For ex., if you want to specify different table names use the following code:
        /* 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Product");
            modelBuilder.Entity<ProductCategories>().ToTable("ProductCategory");
        }
        */
    }
}

