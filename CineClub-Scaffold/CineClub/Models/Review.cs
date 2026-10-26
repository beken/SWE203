
namespace CineClub.Models;
public class Review
{
    public int Id { get; set; } //PK
    public string Content { get; set; }
    public int MovieId { get; set; } //FK
}