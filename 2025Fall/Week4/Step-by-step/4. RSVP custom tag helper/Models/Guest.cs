using System.ComponentModel.DataAnnotations;

namespace RSVPApp.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        //[StringLength(50)]

        public string Name { get; set; }


        [Required(ErrorMessage = "Please enter your phone number so we can contact you if party date changes.")]
        //[StringLength(11)]
        //[RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
        //[Phone]
        public string? Phone { get; set; }

        //[EmailAddress]        
        public string? Email { get; set; }

        public bool WillAttend { get; set; }
    }
}

