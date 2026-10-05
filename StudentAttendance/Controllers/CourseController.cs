using Microsoft.AspNetCore.Mvc;
using StudentAttendanceApp.Models;

namespace StudentAttendanceApp.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public ActionResult Sign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sign(string StudentID)
        {
            Student student = Repository.students().First(s => s.StudentID == StudentID);
            student.Signed = true;

            var studendSignedCount = Repository.students().Where(s => s.Signed == true).Count();
            ViewBag.UserCount = studendSignedCount;

            return View("AttendanceCount");
        }
    }
}
