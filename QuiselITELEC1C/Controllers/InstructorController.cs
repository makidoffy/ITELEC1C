using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuiselITELEC1C.Data;
using QuiselITELEC1C.Models;

namespace QuiselITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbDatas;
        private readonly IWebHostEnvironment _environment;

        public InstructorController(AppDbContext dbDatas, IWebHostEnvironment environment)
        {

            _dbDatas = dbDatas;
            _environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {

            return View(_dbDatas.Instructors);
        }
        public IActionResult ShowDetails(int id)
        {
            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == id);
            
            if (instructor != null)
            { //was an student found?
                if (instructor.StudentProfilePhoto != null)
                {
                    string imageBase64Data = Convert.ToBase64String(instructor.StudentProfilePhoto);
                    string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                    ViewBag.StudentProfilePhoto = imageDataURL;
                }
            }

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newinstructor)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                newinstructor.StudentProfilePhoto = ms.ToArray();
                ms.Close();
                ms.Dispose();
            }

            if (!ModelState.IsValid)
            {
                return View(newinstructor);}

            _dbDatas.Instructors.Add(newinstructor);
            _dbDatas.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)

                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == instructorChanges.Id);
            if (instructor != null)
            {

                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.Rank = instructorChanges.Rank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.Status = instructorChanges.Status;
                instructor.PhoneNumber = instructorChanges.PhoneNumber;
                _dbDatas.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult Delete(Student removeInstructor)
        {

            Instructor? instructor = _dbDatas.Instructors.FirstOrDefault(st => st.Id == removeInstructor.Id);

            if (instructor != null)//was an student found?
                _dbDatas.Instructors.Remove(instructor);
            _dbDatas.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}