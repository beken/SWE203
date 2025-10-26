namespace CineClub.Models;

public class Movie
{
    public int Id { get; set; } //Primary key
    public string Title { get; set; }

    public int GenreId { get; set; } //Foreign key

}

