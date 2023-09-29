using Microsoft.AspNetCore.Mvc;
using QuiselITELEC1C.Models;
using QuiselITELEC1C.Services;

namespace QuiselITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly Interface _dummyData;

        public StudentController(Interface dummyData)
        {
            _dummyData = dummyData;
        }





        public IActionResult Index()
        {

            return View(_dummyData.StudentList);
        }

        public IActionResult ShowDetails(int id)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }



        [HttpGet]
        public IActionResult AddStudent()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AddStudent(Student newstudent)
        {

            _dummyData.StudentList.Add(newstudent);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == studentChanges.Id);

            if (student != null)
            {

                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Course = studentChanges.Course;
                student.Email = studentChanges.Email;
                student.DateEnrolled = studentChanges.DateEnrolled;

            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();

        }


        [HttpPost]
        public IActionResult Delete(Student newstudent)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == newstudent.Id);
            if (student != null)
                _dummyData.StudentList.Remove(student);
            return RedirectToAction("Index");
        }
    }
}

