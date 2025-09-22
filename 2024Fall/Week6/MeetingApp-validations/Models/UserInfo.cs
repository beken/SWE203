using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo{

         public int id{get; set;}

        [Required(ErrorMessage ="error")]  

         public string? Name{get; set;}  

        [Required(ErrorMessage ="error")]       
        public string? Phone{get; set;}

        [Required]  
        [EmailAddress]
         public string? Email{get; set;}

        [Required]  
         public bool? WillAttend{get; set;}
    }
}