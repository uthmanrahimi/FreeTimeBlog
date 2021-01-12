using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Queries
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public int Id { get; set; }

        public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;
            private readonly IDomainEventService _domainEventService;

            public GetPostByIdQueryHandler(IDataContext context, IMapper mapper, IMediator mediator, IDomainEventService domainEventService)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
                _domainEventService = domainEventService;
            }
            public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.Include(p => p.PostTags).ThenInclude(p => p.Tag).SingleOrDefaultAsync(p => p.Id == request.Id);
                await _domainEventService.Publish(new PostViewed(request.Id));
                return _mapper.Map<PostDto>(post);

            }
        }
    }
}
