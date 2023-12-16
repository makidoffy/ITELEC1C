using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuiselITELEC1C.Data;
using QuiselITELEC1C.ViewModels;

namespace QuiselITELEC1C.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;}


        [HttpGet]
        public IActionResult Login()
        {
            return View();}

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInfo)
        {

            var result = await _signInManager.PasswordSignInAsync(loginInfo.Username, loginInfo.Password, loginInfo.Rememberme, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Instructor");}
            else
            {
                ModelState.AddModelError("", "Failed");}

            return View(loginInfo);}
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Instructor");}

        [HttpGet]
        public IActionResult Register()
        {
            return View();}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userEnteredData)
        {
                User newUser = new User();
                newUser.UserName = userEnteredData.Username;
                newUser.FirstName = userEnteredData.FirstName;
                newUser.LastName = userEnteredData.LastName;
                newUser.Email = userEnteredData.Email;
                newUser.PhoneNumber = userEnteredData.Phone;
                var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Instructor");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(userEnteredData);
        }
    }
}