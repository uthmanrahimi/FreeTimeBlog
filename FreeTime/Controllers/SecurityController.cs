using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Application.Models.Entities.Identity;
using FreeTime.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    public class SecurityController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public SecurityController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsNotValid())
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            if (result.Succeeded)
                return RedirectToAction("Index", "Blog");

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Account is locked out.");
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Login Failed. UserName or Password is incorrect");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsNotValid())
            {
                return View(model);
            }

            var user = new User { UserName = model.UserName, FirstName = model.Name };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // confirm code
                //send email
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Blog");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Blog");
        }
    }
}