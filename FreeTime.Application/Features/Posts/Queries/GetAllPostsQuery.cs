using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Queries
{
    public class GetAllPostsQuery : IRequest<Envelope<IEnumerable<PostListDto>>>
    {
        public int Page { get; set; }
        public int PostsPerPage { get; private set; }
        public GetAllPostsQuery(int page, int postsPerPage)
        {
            Page = page;
            PostsPerPage = postsPerPage;
        }


        public class GetAllPostsHandler : IRequestHandler<GetAllPostsQuery, Envelope<IEnumerable<PostListDto>>>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public GetAllPostsHandler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Envelope<IEnumerable<PostListDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
            {
                request.Page = request.Page > 0 ? --request.Page : request.Page;
                int skip = request.Page * request.PostsPerPage;

                var data = await _context.Posts.Include(p => p.Comments).OrderByDescending(p => p.Id).Skip(skip).Take(request.PostsPerPage).ProjectTo<PostListDto>(_mapper.ConfigurationProvider).ToListAsync();
                int total = await _context.Posts.CountAsync();

                return new Envelope<IEnumerable<PostListDto>>(request.Page, total, request.PostsPerPage, data);
            }
        }

    }
}
