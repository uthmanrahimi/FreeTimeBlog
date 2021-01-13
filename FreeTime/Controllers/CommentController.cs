using FreeTime.Application.Features.Comments.Commands;
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
    }
}
