using Microsoft.EntityFrameworkCore;
using CineClub.Models;

namespace CineClub.Data
{
    public class CineDbContext : DbContext
    {
        public CineDbContext(DbContextOptions<CineDbContext> options) : base(options) { }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Review> Reviews => Set<Review>();
    }
}

