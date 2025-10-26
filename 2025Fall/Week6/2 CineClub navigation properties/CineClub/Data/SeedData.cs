using CineClub.Models;

namespace CineClub.Data;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        CineDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CineDbContext>();

        if (context.Genres.Any() || context.Movies.Any() || context.Reviews.Any()) return;

        var g1 = new Genre { Name = "Drama" };
        var g2 = new Genre { Name = "Sci-Fi" };
        context.Genres.AddRange(g1, g2);
        context.SaveChanges();

        var m1 = new Movie { Title = "Godfather", GenreId = g1.Id };
        var m2 = new Movie { Title = "Interstellar", GenreId = g2.Id };
        var m3 = new Movie { Title = "Neşeli Günler", GenreId = g1.Id };
        context.Movies.AddRange(m1, m2, m3);
        context.SaveChanges();

        context.Reviews.AddRange(
            new Review { MovieId = m1.Id, Content = "Nice" },
            new Review { MovieId = m2.Id, Content = "Wow" },
            new Review { MovieId = m3.Id, Content = "Harika" },
            new Review { MovieId = m3.Id, Content = "Mükemmel" }
        );
        context.SaveChanges();
    }
}