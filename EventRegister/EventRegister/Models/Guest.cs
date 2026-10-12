using System.ComponentModel.DataAnnotations;
public class Guest
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool WillAttend { get; set; }
}