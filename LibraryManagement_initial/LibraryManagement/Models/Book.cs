using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = "";

    [Required]
    public string ISBN { get; set; } = "";

    public int PublicationYear { get; set; }

    public int TotalCopies { get; set; }

    [Display(Name = "Author")]
    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public List<Genre> Genres { get; set; } = new();
    public List<Borrowing> Borrowings { get; set; } = new();
}