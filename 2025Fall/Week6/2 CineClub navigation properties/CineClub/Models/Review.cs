namespace CineClub.Models;

public class Review
{
    public int Id { get; set; } //Primary key
    public string Content { get; set; }

    public int MovieId { get; set; } //Foreign key

    public Movie Movie { get; set; } 
}

