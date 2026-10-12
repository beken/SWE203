using System.ComponentModel.DataAnnotations;
public class Guest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters.")]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
        
    [Phone]
    [Required]
    public string Phone { get; set; }
    public bool WillAttend { get; set; }
}