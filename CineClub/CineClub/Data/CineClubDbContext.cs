using Microsoft.EntityFrameworkCore;
using CineClub.Models;

namespace CineClub.Data;
public class CineClubDbContext : DbContext
{
    public CineClubDbContext(DbContextOptions<CineClubDbContext> options) : base(options)
    {
    }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
}