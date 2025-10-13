using System.ComponentModel.DataAnnotations;

namespace RSVPApp.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please share your name")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool WillAttend { get; set; }
    }
}