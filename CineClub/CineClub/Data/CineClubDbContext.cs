using Microsoft.EntityFrameworkCore;
using CineClub.Models;
public class CineClubDbContext : DbContext
{
    public CineClubDbContext(DbContextOptions<CineClubDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}