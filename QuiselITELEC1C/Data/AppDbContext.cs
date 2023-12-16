using QuiselITELEC1C.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuiselITELEC1C.Data;

namespace QuiselITELEC1C.Data
{

    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Rey Knowlf",
                    LastName = "Quisel",
                    Course = Course.IT,
                    DateEnrolled = DateTime.Parse("17/12/2020"),
                    Email = "reyknowlf.quisel.cics@ust.edu.ph",
                    PhoneNumber = "0912-232-1235"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Rhayden Jarren",
                    LastName = "Catris",
                    Course = Course.CS,
                    DateEnrolled = DateTime.Parse("04/04/2020"),
                    Email = "rhaydenjarren.catris.cics@ust.edu.ph",
                    PhoneNumber = "0912-222-1634"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Finn Aaron",
                    LastName = "Icaro",
                    Course = Course.IS,
                    DateEnrolled = DateTime.Parse("04/05/2020"),
                    Email = "finnaaron.icaro.cics@ust.edu.ph",
                    PhoneNumber = "0922-182-4535"
                }
            );


            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Bernand",
                    LastName = "Sanidad",
                    HiringDate = DateTime.Parse("24/01/2020"),
                    Rank = Rank.Professor,
                    PhoneNumber = "0912-345-6789"
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Beatrix",
                    LastName = "Lacsamana",
                    HiringDate = DateTime.Parse("17/04/2017"),
                    Rank = Rank.AssistantProfessor,
                    PhoneNumber = "0911-234-5789"
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Gabriel",
                    LastName = "Montano",
                    HiringDate = DateTime.Parse("12/07/2019"),
                    Rank = Rank.AssociateProfessor,
                    PhoneNumber = "0912-345-6789"
                }
                );
        }
    }
}