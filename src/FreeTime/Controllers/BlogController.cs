using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Features.Comments.Queries;
using FreeTime.Application.Features.Posts.Commands;
using FreeTime.Application.Features.Posts.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace FreeTime.Web.Controllers
{

    public class BlogController : BaseController
    {
        private readonly IApplicationConfiguration _configuration;

        public BlogController(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("")]
        [HttpGet("blog")]
        [HttpGet("index")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await Mediator.Send(new GetPublishedPostsQuery(page, _configuration.PostsPerPage));
            ViewBag.PageOfItems = new StaticPagedList<PostDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var result = await Mediator.Send(new GetPostByIdQuery(id));
            return View(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var result = await Mediator.Send(new GetPostByIdQuery(id));
            return Ok(result);
        }


        public async Task<IActionResult> Category(string category, int page = 1)
        {
            var result = await Mediator.Send(new GetPostsByCategoryQuery(category, page));
            return View(result);
        }

        [Authorize, HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            command.WriterId = LogedInUserId;
            var result = await Mediator.Send(command);
            if (!result)
                return View();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await Mediator.Send(new GetPostByIdQuery(id));
            return View(result);
        }

        [HttpPost("edit/{id}")]
        [Authorize]
        public async Task<IActionResult> Edit(int id, UpdatePostCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.Succeeded)
                return RedirectToAction("manage");
            return View(result.ToString());
        }


        [HttpDelete("api/blog/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeletePostCommand(id));
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.ToString());
        }

        [HttpGet("manage")]
        [Authorize]
        public async Task<IActionResult> Manage(int page = 1)
        {
            var result = await Mediator.Send(new GetAllPostsQuery(page, _configuration.PostsPerPage));
            ViewBag.PageOfItems = new StaticPagedList<PostListDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }

        [Route("manage/comments",Name ="comments")]
        [Authorize]
        public async Task<IActionResult> Comments(int page = 1)
        {
            var result = await Mediator.Send(new GetCommentsQuery(page));
            ViewBag.PageOfItems = new StaticPagedList<CommentDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }

        [Route("/manage/comment/{commentId:int}",Name ="commentdetails")]
        [Authorize]
        public async Task<IActionResult> CommentDetails(int commentId)
        {
            var result = await Mediator.Send(new GetCommentQuery(commentId));
            return View(result);
        }
    }
}