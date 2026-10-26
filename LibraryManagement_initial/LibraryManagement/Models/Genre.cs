using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class Genre
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    public List<Book> Books { get; set; } = new();
}