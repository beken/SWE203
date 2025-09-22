using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models {
    public class StoreDbContext : DbContext {
        
        //constructor sets up the database options
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options) { }
        
        //When the database is created, EF creates tables that have names the same as the DbSet property names. 
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<ProductReview> ProductReviews => Set<ProductReview>();

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<ShippingOrder> ShippingOrders => Set<ShippingOrder>();
        public DbSet<SubscriptionOrder> SubscriptionOrders => Set<SubscriptionOrder>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.products)
                .WithMany(p => p.Orders);

            modelBuilder.Entity<ShippingOrder>()
                .HasBaseType<Order>();
        }
    }
}


