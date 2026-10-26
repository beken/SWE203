using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class Borrowing
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; }

    [Required]
    public string BorrowerName { get; set; } = "";

    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}