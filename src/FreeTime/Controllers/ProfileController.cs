using FreeTime.Application.Features.Profile.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FreeTime.Web.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController()
        {

        }

        public IActionResult Index()
        {
            var result = Mediator.Send(new GetProfileQuery());
            return View(result);
        }
    }
}
