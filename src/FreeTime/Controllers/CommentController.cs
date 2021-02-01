using FreeTime.Application.Features.Comments.Commands;
using FreeTime.Application.Features.Comments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    [Route("api/comments")]
    public class CommentController : BaseController
    {

        [HttpPost("{postId:int}")]
        public async Task<IActionResult> Post(int postId, [FromBody] AddCommentCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("{postId:int}/{page}")]

        public async Task<IActionResult> Get(int postId, int page = 0)
        {
            var comments = await Mediator.Send(new GetPostCommentsQuery(postId, page));
            return PartialView("_CommentsPartial",comments);
        }
    }
}
