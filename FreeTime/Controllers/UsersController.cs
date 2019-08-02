using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FreeTime.Web.Controllers
{
    [Route("users/")]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userid}/posts"), Authorize]
        public async Task<IActionResult> Posts()
        {

            int userId = LogedInUserId;
            var result = await _mediator.Send(new GetUserPostsQuery(userId));
            return View(result);
        }

    }
}
