using Microsoft.EntityFrameworkCore;
using CineClub.Models;
public class CineClubDbContext : DbContext
{
    public CineClubDbContext(DbContextOptions<CineClubDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "The Shawshank Redemption", ReleaseYear = 1994 },
            new Movie { Id = 2, Title = "The Godfather", ReleaseYear = 1972 },
            new Movie { Id = 3, Title = "The Dark Knight", ReleaseYear = 2008 }
        );
    }
}