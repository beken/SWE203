using Microsoft.EntityFrameworkCore;
using CineClub.Models;

namespace CineClub.Data;

public class CineDbContext : DbContext
{
    public CineDbContext(DbContextOptions<CineDbContext> options) : base(options) { }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Review> Reviews => Set<Review>();

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ------------------------------------------------------------------
        // Relationship: Movie and Review (One-to-Many)
        // A Movie can have many Reviews, but a Review belongs to only one Movie.
        // ------------------------------------------------------------------
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Movie)          // Defines the relationship from the 'many' side: A Review has ONE Movie.
            .WithMany(m => m.Reviews)      // Defines the relationship from the 'one' side: A Movie has MANY Reviews.
            .HasForeignKey(r => r.MovieId) // Specifies MovieId in the Review table as the Foreign Key.
            .OnDelete(DeleteBehavior.Cascade); // **CASCADE DELETE:** If a Movie is deleted, all associated Reviews are automatically deleted from the database.

        // ------------------------------------------------------------------
        // Relationship: Genre and Movie (One-to-Many)
        // A Genre can have many Movies, but a Movie belongs to only one Genre.
        // ------------------------------------------------------------------
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)          // Defines the relationship from the 'many' side: A Movie has ONE Genre.
            .WithMany(g => g.Movies)       // Defines the relationship from the 'one' side: A Genre has MANY Movies.
            .HasForeignKey(m => m.GenreId) // Specifies GenreId in the Movie table as the Foreign Key.
            .OnDelete(DeleteBehavior.Restrict); // **RESTRICT DELETE:** If a Genre is deleted, the database will throw an error if there are still Movies associated with that Genre. This prevents accidental deletion of Genres that are in use.
    }

}