using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = "";

    public List<Book> Books { get; set; } = new();
}