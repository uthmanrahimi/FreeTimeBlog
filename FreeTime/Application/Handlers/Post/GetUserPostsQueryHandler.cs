using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models.Dto;
using FreeTime.Web.Application.Queries.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers.Post
{
    public class GetUserPostsQueryHandler : IRequestHandler<GetUserPostsQuery, IEnumerable<UserPostsDto>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public GetUserPostsQueryHandler(ApplicationContext context,IMapper mapper)
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
