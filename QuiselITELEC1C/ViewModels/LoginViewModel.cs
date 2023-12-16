using System.ComponentModel.DataAnnotations;

namespace QuiselITELEC1C.ViewModels
{
    public class LoginViewModel
    { 
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Input is not correct")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Input is Not Correct")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        [Required(ErrorMessage = "Failed")]
        public bool Rememberme { get; set; }

    }
}
