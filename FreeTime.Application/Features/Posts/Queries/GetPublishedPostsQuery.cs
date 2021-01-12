using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.ExtensionMethods;
using FreeTime.Application.Common.Interfaces;
using FreeTime.Domain.Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Queries
{
    public class GetPublishedPostsQuery : IRequest<Envelope<IEnumerable<PostDto>>>
    {
        public int Page { get; set; }
        public int PostsPerPage { get; set; }
        public GetPublishedPostsQuery(int page, int postsPerPage = 10)
        {
            Page = page;
            PostsPerPage = postsPerPage;
        }

        public class GetPostsQueryHandler : IRequestHandler<GetPublishedPostsQuery, Envelope<IEnumerable<PostDto>>>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public GetPostsQueryHandler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Envelope<IEnumerable<PostDto>>> Handle(GetPublishedPostsQuery request, CancellationToken cancellationToken)
            {

                int resultForSkip = (request.Page - 1) * request.PostsPerPage;

                var data = await _context.Posts.Include(p => p.PostTags)
                    .ThenInclude(p => p.Tag)
                    .Where(p => p.Status == PostStatus.Published)
                    .OrderByDescending(r => r.CreatedOn).Skip(resultForSkip).Take(request.PostsPerPage)
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();

                var totalCount = await _context.Posts.TotalCountAsync(p => p.Status == PostStatus.Published);
                return new Envelope<IEnumerable<PostDto>>(request.Page, totalCount, 10, data);

            }


        }
    }
}
