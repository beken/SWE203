using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo{

         public int id{ get; set;}

        [Required]
         public string? Name{get; set;}  

        [Required]
         public string? Phone{get; set;}

        [Required]
        [EmailAddress]
         public string? Email{get; set;}

        [Required]
         public bool? WillAttend{get; set;}
    }
}