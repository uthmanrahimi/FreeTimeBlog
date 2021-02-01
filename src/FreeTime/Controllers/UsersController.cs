using FreeTime.Application.Features.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FreeTime.Web.Controllers
{
    [Route("users/")]
    public class UsersController : BaseController
    {
        public UsersController()
        {
        }

        [HttpGet("{userid}/posts"), Authorize]
        public async Task<IActionResult> Posts()
        {

            int userId = LogedInUserId;
            var result = await Mediator.Send(new GetUserPostsQuery(userId));
            return View(result);
        }

    }
}
