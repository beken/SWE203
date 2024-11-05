using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models
{
    public class SportsStoreDBContext : DbContext {
        public SportsStoreDBContext(DbContextOptions<SportsStoreDBContext> options) : base(options){}

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    }
}
