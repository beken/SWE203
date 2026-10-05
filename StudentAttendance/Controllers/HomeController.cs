using Microsoft.AspNetCore.Mvc;
using StudentAttendanceApp.Models;

namespace StudentAttendanceApp.Controllers{
    public class HomeController: Controller {
        public ActionResult Index(){
            ViewBag.CourseCode = "SWE 203";
            ViewBag.CourseName = "Web Programming";
            ViewBag.WeeklyDay = "Monday";
            ViewBag.WeeklyHour = "13:00 - 16:00";

            var students = Repository.students().Where(s => s.Signed == true);

            return View(students);
        }
    }
}