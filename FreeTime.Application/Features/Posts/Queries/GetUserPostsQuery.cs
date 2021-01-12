using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Application.Common.DTOs.Posts;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Posts.Queries
{
    public class GetUserPostsQuery : IRequest<IEnumerable<UserPostsDto>>
    {
        public int UserId { get; private set; }

        public GetUserPostsQuery(int userId)
        {
            UserId = userId;
        }

        public class GetUserPostsQueryHandler : IRequestHandler<GetUserPostsQuery, IEnumerable<UserPostsDto>>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public GetUserPostsQueryHandler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UserPostsDto>> Handle(GetUserPostsQuery request, CancellationToken cancellationToken)
            {
                if (request.UserId == 0) throw new ArgumentException($"UserId could not be zero.");
                return await _context.Posts.Where(p => p.WriterId == request.UserId).OrderByDescending(p => p.Id).ProjectTo<UserPostsDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
