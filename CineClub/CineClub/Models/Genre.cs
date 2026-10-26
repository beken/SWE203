namespace CineClub.Models;

public class Genre
{
    public int Id { get; set; } //PK

    public string Name { get; set; }

    public List<Movie> Movies { get; set; } //Navigation property
}
