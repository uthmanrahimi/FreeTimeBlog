using Microsoft.AspNetCore.Mvc;

namespace FreeTime.Web.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
