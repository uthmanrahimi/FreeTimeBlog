using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Queries.Posts;
using FreeTime.Web.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPublishedPostsQuery, Envelope<IEnumerable<PostDto>>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public GetPostsQueryHandler(ApplicationContext context, IMapper mapper, IPostService postService)
        {
            _context = context;
            _mapper = mapper;
            _postService = postService;
        }

        public async Task<Envelope<IEnumerable<PostDto>>> Handle(GetPublishedPostsQuery request, CancellationToken cancellationToken)
        {

            int resultForSkip = (request.Page - 1) * request.PostsPerPage;

            var data = await _context.Posts.Include(p => p.PostTags)
                .ThenInclude(p => p.Tag)
                .Where(p => p.Status == PostStatus.Published)
                .OrderByDescending(r => r.CreatedOn).Skip(resultForSkip).Take(request.PostsPerPage)
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();

            var totalCount =await _context.Posts.TotalCountAsync(p => p.Status == PostStatus.Published);
            return new Envelope<IEnumerable<PostDto>>(request.Page, totalCount, 10, data);

        }


    }
}
