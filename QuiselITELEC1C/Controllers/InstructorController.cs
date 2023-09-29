using Microsoft.AspNetCore.Mvc;
using QuiselITELEC1C.Models;
using QuiselITELEC1C.Services;

namespace QuiselITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly Interface _dummyData;

        public InstructorController (Interface dummyData)
        {
            _dummyData = dummyData;
        }

        public IActionResult Index()
        {

            return View(_dummyData.InstructorList);
        }

        public IActionResult ShowDetails(int id)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == id);

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

            _dummyData.InstructorList.Add(newinstructor);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {

            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == instructorChanges.Id);

            if (instructor != null)
            {

                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.Rank = instructorChanges.Rank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;


            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();

        }


        [HttpPost]
        public IActionResult Delete(Instructor newinstructor)
        {

            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == newinstructor.Id);
            if (instructor != null)
                _dummyData.InstructorList.Remove(instructor);
            return RedirectToAction("Index");
        }
    }

}

