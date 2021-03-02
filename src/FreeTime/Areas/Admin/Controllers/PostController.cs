using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Features.Posts.Commands;
using FreeTime.Application.Features.Posts.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace FreeTime.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/post")]
    public class PostController : ProtectedController
    {
        private readonly IApplicationConfiguration _configuration;
        private readonly IMapper _mapper;

        public PostController(IApplicationConfiguration configuration,IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await Mediator.Send(new GetAllPostsQuery(page, _configuration.PostsPerPage));
            ViewBag.PageOfItems = new StaticPagedList<PostListDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }

        [ HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
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
 
        public async Task<IActionResult> Edit(int id)
        {
            var result = await Mediator.Send(new GetPostByIdQuery(id));
            return View(result);
        }

        [HttpPost("edit/{id}")]
   
        public async Task<IActionResult> Edit(int id, UpdatePostCommand command)
        {
            if (!ModelState.IsValid)
                return View(_mapper.Map<PostDto>(command));
            var result = await Mediator.Send(command);
            if (result.Succeeded)
                return RedirectToAction("index");
            return View(_mapper.Map<PostDto>(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeletePostCommand(id));
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.ToString());
        }


    }
}
