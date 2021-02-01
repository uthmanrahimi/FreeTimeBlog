using FreeTime.Application.Common.Interfaces;
using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IIdentityService _identityService;

        public SecurityController(IIdentityService identityService)
        {
            _identityService = identityService;
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
            var result = await _identityService.SignInAsync(model.UserName, model.Password, model.RememberMe, true);// _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            if (result.Succeeded)
                return RedirectToAction("Index", "Blog");

            ModelState.AddModelError(string.Empty, result.ToString());
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
                return View(model);

            var result = await _identityService.CreateUserAsync(model.UserName, model.Password);
            if (result.Succeeded)
                return RedirectToAction("Index", "Blog");

            ModelState.AddModelError(string.Empty, result.ToString());

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _identityService.LogOutAsync();
            return RedirectToAction("Index", "Blog");
        }
    }
}