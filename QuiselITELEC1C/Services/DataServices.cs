using QuiselITELEC1C.Models;
using QuiselITELEC1C.Services;
namespace QuiselITELEC1C.Services
{
    public class DataServices : Interface
    {
        public List<Student> StudentList { get; }
        public List<Instructor> InstructorList { get; }

        public DataServices()
        {
           StudentList = new List<Student>
            {
            new Student()
            {
                Id= 1, FirstName = "Rey Knowlf", LastName = "Quisel", Course = Course.IT , DateEnrolled = DateTime.Parse("17/12/2020"), Email = "reyknowlf.quisel.cics@ust.edu.ph"

            },
            new Student()
            {
                Id= 2, FirstName = "Rhayden Jarren", LastName = "Catris", Course = Course.CS , DateEnrolled = DateTime.Parse("04/04/2020"), Email = "rhaydenjarren.catris.cics@ust.edu.ph"
            },
            new Student()
            {
                Id= 3, FirstName = "Finn Aaron", LastName = "Icaro", Course = Course.IS, DateEnrolled = DateTime.Parse("04/05/2020"), Email = "finnaaron.icaro.cics@ust.edu.ph"
            }

            };

            InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id= 1,FirstName = "Bernard", LastName = "Sanidad", Rank = Rank.Professor,
                HiringDate = DateTime.Parse("24/01/2020")
            },
            new Instructor()
            {
                Id= 2,FirstName = "Beatrix", LastName = "Lacsamana", Rank = Rank.AssistantProfessor,
                HiringDate = DateTime.Parse("17/04/2017")
            },
            new Instructor()
            {
                Id= 3,FirstName = "Gabriel", LastName = "Montano", Rank = Rank.AssociateProfessor,
                HiringDate = DateTime.Parse("12/07/2019")
            }
        };



        }
    }
}




