using AutoMapper;
using FreeTime.Web.Application.Commands;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeTime.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Posts")]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            this._mapper = mapper;
        }

        [HttpGet("get/{page}/{take}")]
        public async Task<IActionResult> Get(int page, int take)
        {
            var result = await _mediator.Send(new GetPostsQuery { Page = page-1, Take = 10 });
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreatePostViewModel post)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = _mapper.Map<CreatePostCommand>(post);
            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UpdatePostViewModel post)
        {
            var command = _mapper.Map<UpdatePostCommand>(post);
            var result = await _mediator.Send(command);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.ToString());
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePostCommand { Id = id });
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.ToString());
        }
    }
}