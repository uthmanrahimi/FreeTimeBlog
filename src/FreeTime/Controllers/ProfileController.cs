using FreeTime.Application.Features.Profile.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    [Route("Profile")]
    public class ProfileController : BaseController
    {
        public ProfileController()
        {

        }


        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var result =await Mediator.Send(new GetProfileQuery());
            return View(result);
        }
    }
}
