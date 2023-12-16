using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuiselITELEC1C.Data;
using QuiselITELEC1C.Models;
using QuiselITELEC1C.Services;

namespace QuiselITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbData;
        private readonly IWebHostEnvironment _environment;

        public StudentController(AppDbContext dbData, IWebHostEnvironment environment)
        {

            _dbData = dbData;
            _environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {

            return View(_dbData.Students);
        }

        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)
            {
                if (student.StudentProfilePhoto != null)
                {
                    string imageBase64Data = Convert.ToBase64String(student.StudentProfilePhoto);
                    string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                    ViewBag.StudentProfilePhoto = imageDataURL;
                }
                return View(student);
            }


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
            if(Request.Form.Files.Count > 0) { 
            var file = Request.Form.Files[0];
            
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                newstudent.StudentProfilePhoto = ms.ToArray();
                ms.Close();
                ms.Dispose();
            }
            _dbData.Students.Add(newstudent);
            _dbData.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);
            if (student != null)//was an student found?
                return View(student);
            return NotFound();}

        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == studentChanges.Id);

            if (student != null)
            {

                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Course = studentChanges.Course;
                student.Email = studentChanges.Email;
                student.DateEnrolled = studentChanges.DateEnrolled;
                _dbData.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

        }

        [HttpPost]
        public IActionResult Delete(Student removeStudent)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == removeStudent.Id);

            if (student != null)//was an student found?
                _dbData.Students.Remove(student);
            _dbData.SaveChanges();
            return RedirectToAction("Index");

        }





    }

}