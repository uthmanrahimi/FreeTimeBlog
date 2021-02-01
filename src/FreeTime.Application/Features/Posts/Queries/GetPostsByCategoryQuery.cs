using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.ExtensionMethods;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Queries
{
    public class GetPostsByCategoryQuery : IRequest<Envelope<IEnumerable<PostDto>>>
    {
        public string Category { get; private set; }
        public int PageIndex { get; private set; }
        public GetPostsByCategoryQuery(string category, int pageIndex)
        {
            Category = category;
            PageIndex = pageIndex;
        }

        public class GetPostsByCategoryQueryHandler : IRequestHandler<GetPostsByCategoryQuery, Envelope<IEnumerable<PostDto>>>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public GetPostsByCategoryQueryHandler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Envelope<IEnumerable<PostDto>>> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
            {
                var tag = await _context.Tags.SingleOrDefaultAsync(t => t.Name == request.Category);
                if (tag == null) return Envelope<PostDto>.Empty();
                var count = _context.Posts.TotalCount(p => p.PostTags.Any(pt => pt.TagId == tag.Id));
                var posts = await _context.Posts.Where(p => p.PostTags.Any(pt => pt.TagId == tag.Id)).ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
                return Envelope<IEnumerable<PostDto>>.New(request.PageIndex, count, 10, posts);

            }
        }
    }
}
