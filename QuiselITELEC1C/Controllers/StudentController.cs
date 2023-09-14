using Microsoft.AspNetCore.Mvc;
using QuiselITELEC1C.Models;

namespace QuiselITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
        {
            new Student()
            {
                Id= 1, FirstName = "Reyknowlf", LastName = "Quisel", Course = Course.IT , DateEnrolled = DateTime.Parse("17/12/2020"), Email = "reyknowlf.quisel.cics@ust.edu.ph"

            },
            new Student()
            {
                Id= 2, FirstName = "Latino", LastName = "Marie", Course = Course.CS , DateEnrolled = DateTime.Parse("04/04/2020"), Email = "latino.marie.cics@ust.edu.ph"
            },
            new Student()
            {
                Id= 3, FirstName = "Luis", LastName = "Granada", Course = Course.IS, DateEnrolled = DateTime.Parse("04/05/2020"), Email = "luisenrico.granada.cics@ust.edu.ph"
            }
        };
        public IActionResult Index()
        {

            return View(StudentList);
        }

        public IActionResult ShowDetails(int id)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

    }

}
