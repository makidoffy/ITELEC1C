using QuiselITELEC1C.Models;
namespace QuiselITELEC1C.Services
{
    public interface Interface
    {
       List<Student> StudentList { get; }
       List<Instructor> InstructorList { get; }
    }
}
