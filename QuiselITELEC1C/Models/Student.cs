using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QuiselITELEC1C.Models
{

    public enum Course
    {
        CS, IT, IS
    }

    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course is Required")]
        public Course Course { get; set; }
        [Display(Name = "Date Enrolled")]
        [Required(ErrorMessage = "Date Enrolled is Required")]
        [DataType(DataType.Date)]
        public DateTime DateEnrolled { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{4}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the format 000-000-0000")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Profile Picture")]
        public byte[]? StudentProfilePhoto { get; set; }

    }
}
