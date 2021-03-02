using FreeTime.Application.Common.Interfaces;
using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    [Route("Security")]
    public class SecurityController : Controller
    {
        private readonly IIdentityService _identityService;

        public SecurityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsNotValid())
            {
                return View(model);
            }

            var result = await _identityService.SignInAsync(model.UserName, model.Password, model.RememberMe, true);
            if (result.Succeeded)
                return RedirectToAction("Index", "Blog");

            ModelState.AddModelError(string.Empty, result.ToString());
            return View(model);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
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

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _identityService.LogOutAsync();
            return RedirectToAction("Index", "Blog");
        }
    }
}