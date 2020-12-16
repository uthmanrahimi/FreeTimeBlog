using AutoMapper;
using FreeTime.Web.Application;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace FreeTime.Web.Controllers
{

    public class BlogController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IApplicationConfiguration _configuration;

        public BlogController(IMediator mediator, IMapper mapper, IApplicationConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("")]
        [HttpGet("blog")]
        [HttpGet("index")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _mediator.Send(new GetPublishedPostsQuery(page,_configuration.PostsPerPage));
            ViewBag.PageOfItems = new StaticPagedList<PostDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id, string slug)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return View(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return Ok(result);
        }


        public async Task<IActionResult> Category(string category, int page = 1)
        {
            var result = await _mediator.Send(new GetPostsByCategoryQuery(category, page));
            return View(result);
        }

        [Authorize, HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostViewModel post)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = _mapper.Map<CreatePostCommand>(post);
            command.WriterId = LogedInUserId;
            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return View(result);
        }

        [HttpPost("edit/{id}")]
        [Authorize]
        public async Task<IActionResult> Edit(int id, UpdatePostViewModel post)
        {
            var command = _mapper.Map<UpdatePostCommand>(post);
            var result = await _mediator.Send(command);
            if (result.Succeeded)
                return RedirectToAction("manage");
            return BadRequest(result.ToString());
        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePostCommand { Id = id });
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.ToString());
        }

        [HttpGet("manage")]
        public async Task<IActionResult> Manage(int page = 1)
        {
            var result = await _mediator.Send(new GetAllPostsQuery(page, _configuration.PostsPerPage));
            ViewBag.PageOfItems = new StaticPagedList<PostListDto>(result.Data, page, result.PerPage, result.Total);
            return View(result);
        }
    }
}