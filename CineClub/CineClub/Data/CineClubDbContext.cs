using Microsoft.EntityFrameworkCore;
using CineClub.Models;
public class CineClubDbContext : DbContext
{
    public CineClubDbContext(DbContextOptions<CineClubDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(
            new Genre {Id = 1, Name = "Comedy"},
            new Genre {Id = 2, Name = "Drama"},
            new Genre {Id = 3, Name = "Action"}
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "The Shawshank Redemption", ReleaseYear = 1994, GenreId = 1 },
            new Movie { Id = 2, Title = "The Godfather", ReleaseYear = 1972 , GenreId = 2 },
            new Movie { Id = 3, Title = "The Dark Knight", ReleaseYear = 2008, GenreId = 3 }
        );
    }
}