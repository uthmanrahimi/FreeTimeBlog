using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Web.Application.Extensions;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers.Post
{
    public class GetPostsByCategoryQueryHandler : IRequestHandler<GetPostsByCategoryQuery, Envelope<IEnumerable<PostDto>>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public GetPostsByCategoryQueryHandler(ApplicationContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Envelope<IEnumerable<PostDto>>> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.Where(t => t.Name == request.Category).SingleOrDefaultAsync();
            if (tag == null) return Envelope<PostDto>.Empty();
            var count = _context.Posts.TotalCount(p => p.PostTags.Any(pt => pt.TagId == tag.Id));
            var posts = await _context.Posts.Where(p => p.PostTags.Any(pt => pt.TagId == tag.Id)).ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
            return  Envelope<IEnumerable<PostDto>>.New(request.PageIndex, count, 10, posts);

        }
    }
}
