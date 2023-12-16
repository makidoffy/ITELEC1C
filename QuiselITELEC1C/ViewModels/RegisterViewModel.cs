using System.ComponentModel.DataAnnotations;

namespace QuiselITELEC1C.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter your username")]
        public string? Username { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter your password")]
        public string? Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter your first name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter your last name")]
        public string? LastName { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter your email")]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{2}-[0-9]{3}-[0-9]{4}", ErrorMessage = "format 00-000-0000")]
        public string? Phone { get; set; }

    }
}
