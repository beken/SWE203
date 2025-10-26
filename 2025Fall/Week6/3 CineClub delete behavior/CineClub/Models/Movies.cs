namespace CineClub.Models;

public class Movie
{
    public int Id { get; set; } //Primary key
    public string Title { get; set; }

    public int GenreId { get; set; } //Foreign key

    public Genre? Genre { get; set; }

    public List<Review> Reviews { get; set; }
}

