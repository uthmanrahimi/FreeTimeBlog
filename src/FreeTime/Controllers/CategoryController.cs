using FreeTime.Application.Features.Tags.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{

    public class CategoryController : BaseController
    {

        [HttpGet("categories/popular")]
        public async Task<IActionResult> Popular()
        {
            var result = await Mediator.Send(new GetPopularTagsQuery());
            return View(result);
        }
    }
}
