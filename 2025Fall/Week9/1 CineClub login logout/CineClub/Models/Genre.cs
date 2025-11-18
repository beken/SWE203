using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineClub.Models;

public class Genre
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
