using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Features.Comments.Commands;
using FreeTime.Application.Features.Comments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace FreeTime.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/comment")]
    public class CommentController : ProtectedController
    {

        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await Mediator.Send(new GetCommentsQuery(page));
            ViewBag.PageOfItems = new StaticPagedList<CommentDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }

        [HttpGet("details/{commentId}")]
        public async Task<IActionResult> Details(int commentId)
        {
            var result = await Mediator.Send(new GetCommentQuery(commentId));
            return View(result);
        }

        [HttpPost("updateStatus/{commentId}/{status}")]
        public async Task<IActionResult> POST(int commentId, bool status)
        {
            await Mediator.Send(new UpdateCommentStatusCommand(commentId, status));
            return NoContent();
        }

        [HttpDelete("{commentId:int}")]
        public async Task<IActionResult> Delete(int commentId)
        {
            await Mediator.Send(new DeleteCommentCommand(commentId));
            return NoContent();
        }
    }
}
