using AutoMapper;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BlogController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

       
        public async Task<IActionResult> Index(int page=1)
        {
           
            var result = await _mediator.Send(new GetPostsQuery { Page = page, Take = 10 });
            return View(result);
        }
    
        public async Task<IActionResult> Details(int id,string slug)
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
        [HttpGet,Authorize]
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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Edit(UpdatePostViewModel post)
        {
            var command = _mapper.Map<UpdatePostCommand>(post);
            var result = await _mediator.Send(command);
            if (result.Succeeded)
                return Ok(result);
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
    }
}