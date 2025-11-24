using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CineClub.Models;

namespace CineClub.Data;
public static class SeedCineData {

    //IApplicationBuilder interface used to register middleware components to handle HTTP requests
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        CineDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CineDbContext>();
        CineIdentityDbContext contextIdentity = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CineIdentityDbContext>();
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        //If there are no objects in the database, then the database is populated using a collection of Product objects 
        if (!context.Genres.Any())
        {
            var genres = new List<Genre>
            {
                /*
                new Genre { Id = 1, Name = "Action" },
                new Genre {  Id = 2, Name = "Drama" },
                new Genre {  Id = 3, Name = "Comedy" },
                new Genre {  Id = 4, Name = "Sci-Fi" }
                */
                // OR allow EF Core to automaically assign Ids 
                new Genre { Name = "Action" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Thriller" },
                new Genre { Name = "Animation" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Documentary" },
                new Genre { Name = "Fantasy" }
            };
            context.Genres.AddRange(genres);
            context.SaveChanges();
        }

        if (!context.Movies.Any())
        {
            var sciFi = context.Genres.FirstOrDefault(g => g.Name == "Sci-Fi");
            var drama = context.Genres.FirstOrDefault(g => g.Name == "Drama");
            var comedy = context.Genres.FirstOrDefault(g => g.Name == "Comedy");
            var action = context.Genres.FirstOrDefault(g => g.Name == "Action");
            var horror = context.Genres.FirstOrDefault(g => g.Name == "Horror");
            var thriller = context.Genres.FirstOrDefault(g => g.Name == "Thriller");
            var animation = context.Genres.FirstOrDefault(g => g.Name == "Animation");
            var romance = context.Genres.FirstOrDefault(g => g.Name == "Romance"); 
            var documentary = context.Genres.FirstOrDefault(g => g.Name == "Documentary"); 
            var fantasy = context.Genres.FirstOrDefault(g => g.Name == "Fantasy"); 

            var movies = new List<Movie>
            {
                new Movie
                {
                    //Id = 1,
                    Title = "Inception",
                    Description = "A thief who steals corporate secrets through dream-sharing technology.",
                    ReleaseYear = 2010,
                    //GenreId = 4
                    GenreId = sciFi.Id
                },
                new Movie
                {
                    //Id = 2,
                    Title = "The Godfather",
                    Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                    ReleaseYear = 1972,
                    //GenreId = 2
                    GenreId = drama.Id
                },
                new Movie
                {
                    //Id = 3,
                    Title = "Interstellar",
                    Description = "A team of explorers travel through a wormhole in space.",
                    ReleaseYear = 2014,
                    //GenreId = 4
                    GenreId = sciFi.Id
                },
                new Movie
                {
                    //Id = 4,
                    Title = "Superbad",
                    Description = "Two high school seniors deal with separation anxiety.",
                    ReleaseYear = 2007,
                    //GenreId = 3
                    GenreId = comedy.Id
                },
                new Movie
                {
                    //Id = 5,
                    Title = "The Dark Knight",
                    Description = "Batman faces the Joker, a criminal mastermind who threatens Gotham.",
                    ReleaseYear = 2008,
                    //GenreId = 1
                    GenreId = action.Id
                },
                new Movie
                {
                    //Id = 6,
                    Title = "Psycho",
                    Description = "A secretary steals money and goes on the run, ending up at a secluded motel.",
                    ReleaseYear = 1960,
                    //GenreId = 5
                    GenreId = horror.Id
                },
                new Movie
                {
                    //Id = 7,
                    Title = "Parasite",
                    Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                    ReleaseYear = 2019,
                    //GenreId = 6
                    GenreId = thriller.Id
                },
                new Movie // Added Movie 8
                {
                    //Id = 8,
                    Title = "Spirited Away",
                    Description = "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits.",
                    ReleaseYear = 2001,
                    //GenreId = 7
                    GenreId = animation.Id
                },
                 new Movie // Added Movie 9
                {
                    //Id = 9,
                    Title = "La La Land",
                    Description = "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.",
                    ReleaseYear = 2016,
                    //GenreId = 8
                    GenreId = romance.Id
                },
                new Movie // Added Movie 10
                {
                    //Id = 10,
                    Title = "Pulp Fiction",
                    Description = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    ReleaseYear = 1994,
                    //GenreId = 2
                    GenreId = drama.Id
                },
                new Movie // Added Movie 11
                {
                    //Id = 11,
                    Title = "Planet Earth",
                    Description = "A documentary series on the natural world, narrated by David Attenborough.",
                    ReleaseYear = 2006,
                    //GenreId = 9
                    GenreId = documentary.Id
                },
                new Movie // Added Movie 12
                {
                    //Id = 12,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Description = "A young hobbit, Frodo Baggins, inherits a magical ring that is the key to the Dark Lord Sauron's plan to conquer Middle-earth.",
                    ReleaseYear = 2001,
                    //GenreId = 10
                    GenreId = fantasy.Id
                },
                new Movie // Added Movie 13
                {
                    //Id = 13,
                    Title = "Whiplash",
                    Description = "A promising young drummer enrolls at a cut-throat music conservatory where he encounters an instructor who will stop at nothing to realize a student's potential.",
                    ReleaseYear = 2014,
                    //GenreId = 2
                    GenreId = drama.Id
                }
            };
            context.Movies.AddRange(movies);
            context.SaveChanges();
        }

        if (!context.Reviews.Any())
        {
            var firstMovie = context.Movies.First(); // get the first movie in database
            var darkKnight = context.Movies.FirstOrDefault(m => m.Title == "The Dark Knight");
            var inception = context.Movies.FirstOrDefault(m => m.Title == "Inception");
            var parasite = context.Movies.FirstOrDefault(m => m.Title == "Parasite");
            var whiplash = context.Movies.FirstOrDefault(m => m.Title == "Whiplash");

            var adminUser = userManager.FindByNameAsync("Admin").GetAwaiter().GetResult();
            var adminUserId = adminUser.Id;


            context.Reviews.Add(new Review
            {
                //Id = 1,
                MovieId = firstMovie.Id,
                Content = "Great movie!",
                Rating = 5,
                UserId = adminUserId
            });
            context.Reviews.Add(new Review
            {
                //Id = 2,
                MovieId = darkKnight.Id,
                Content = "A masterpiece of the action genre.",
                Rating = 5,
                UserId = adminUserId
            });
            context.Reviews.Add(new Review
            {
                //Id = 3,
                MovieId = inception.Id,
                Content = "Mind-bending and visually stunning.",
                Rating = 5,
                UserId = adminUserId
            });
            context.Reviews.Add(new Review
            {
                //Id = 4,
                MovieId = parasite.Id,
                Content = "A brilliant social commentary.",
                Rating = 5,
                UserId = adminUserId
            });
            context.Reviews.Add(new Review
            {
                //Id = 5,
                MovieId = whiplash.Id,
                Content = "Intense and unforgettable performance.",
                Rating = 5,
                UserId = adminUserId
            });
            context.SaveChanges();
        }
    }
}
