using AutoMapper;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Notifications;
using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetPostByIdQueryHandler(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.Include(p => p.PostTags).ThenInclude(p => p.Tag).SingleOrDefaultAsync(p => p.Id == request.Id);
            await _mediator.Publish(new PostViewed(request.Id));
            return _mapper.Map<PostDto>(post);

        }
    }
}
