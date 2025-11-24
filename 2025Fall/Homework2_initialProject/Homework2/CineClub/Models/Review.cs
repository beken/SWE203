using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CineClub.Models;

public class Review
{
    public int Id { get; set; }

    [Required, StringLength(2000)]
    public string Content { get; set; } = default!;

    [Range(1, 5)]
    public int? Rating { get; set; } = 5;

    public DateTime? CreatedAtUtc { get; set; } = DateTime.UtcNow;

    [Required]
    public int MovieId { get; set; }

    // Navigation property for movie
    public Movie? Movie { get; set; }

    // Link reviews to users 
    public string? UserId { get; set; } 

}
