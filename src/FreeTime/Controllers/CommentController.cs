using FreeTime.Application.Features.Comments.Commands;
using FreeTime.Application.Features.Comments.Queries;
using FreeTime.Web.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    [Route("api/comments")]
    public class CommentController : BaseController
    {

        [HttpPost("{postId:int}")]
        public async Task<IActionResult> Post(int postId, [FromBody] AddCommentCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Errors().First());
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{postId:int}/{page}")]
        public async Task<IActionResult> Get(int postId, int page = 0)
        {
            var comments = await Mediator.Send(new GetApprovedPostCommentsQuery(postId, page));
            return PartialView("_CommentsPartial", comments);
        }

        [HttpPost("updateStatus/{commentId}/{status}")]
        public async Task<IActionResult> POST(int commentId, bool status)
        {
            await Mediator.Send(new UpdateCommentStatusCommand(commentId, status));
            return NoContent();
        }
    }
}
