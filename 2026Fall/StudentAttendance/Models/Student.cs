using Microsoft.AspNetCore.Mvc;
namespace StudentAttendanceApp.Models {
    public class Student {
       public string StudentID {get; set;}
       public string Name {get; set;}
       public bool Signed {get; set;}
    }
}
