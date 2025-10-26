namespace CineClub.Models;

public class Genre
{
    public int Id { get; set; } //Primary key
    public string Name { get; set; }

    public List<Movie> Movies { get; set; }
}
