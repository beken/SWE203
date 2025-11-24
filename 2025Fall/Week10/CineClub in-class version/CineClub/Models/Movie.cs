using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineClub.Models;

public class Movie
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Title { get; set; }

    [StringLength(4000)]
    public string? Description { get; set; }

    [Range(1895, 2100)]
    public int? ReleaseYear { get; set; }

    // Foreign key
    [Required]
    public int GenreId { get; set; }

    // Navigation properties
    public Genre? Genre { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

}
