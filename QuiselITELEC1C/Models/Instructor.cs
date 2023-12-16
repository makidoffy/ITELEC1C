using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QuiselITELEC1C.Models
{
    public enum Rank
    {AssociateProfessor, Professor, Instructor, AssistantProfessor,}

    public enum Status
    {
        Provisionary, Permanent
    }

    public class Instructor

    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required ")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Display(Name = "Rank")]
        [Required(ErrorMessage = "Rank is Required")]
        public Rank Rank { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is Required")]
        public Status Status { get; set; }
        [Display(Name = "Hiring Date")]
        [Required(ErrorMessage = "Hiring Date is Required")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{4}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the format 000-000-0000")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[]? StudentProfilePhoto { get; set; }
    }
}
