
namespace CineClub.Models;
public class Movie
{
    public int Id { get; set; } //PK
    public string Title { get; set; }
    public int GenreId { get; set; } //FK
}