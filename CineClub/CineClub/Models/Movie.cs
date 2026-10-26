namespace CineClub.Models;

public class Movie
{
    public int Id { get; set; } //PK
    public string Title { get; set; }
    public int ReleaseYear { get; set; }

    public int GenreId { get; set; } //FK

    public Genre Genre { get; set; } //Navigation property
}