using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Application.Features.Posts.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace FreeTime.Web.Controllers
{

    public class BlogController : BaseController
    {
        private readonly IApplicationConfiguration _configuration;
        private readonly IMapper _mapper;

        public BlogController(IApplicationConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
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

        [HttpGet("category")]
        public async Task<IActionResult> Category(string category, int page = 1)
        {
            var result = await Mediator.Send(new GetPostsByCategoryQuery(category, page));
            return View(result);
        }
    }
}