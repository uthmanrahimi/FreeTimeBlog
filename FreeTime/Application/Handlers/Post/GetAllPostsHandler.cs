using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Web.Application.Infrastructures;
using FreeTime.Web.Application.Models;
using FreeTime.Web.Application.Models.Dto;
using FreeTime.Web.Application.Queries.Posts;
using FreeTime.Web.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Web.Application.Handlers.Post
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPostsQuery, Envelope<IEnumerable<PostListDto>>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public GetAllPostsHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Envelope<IEnumerable<PostListDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            request.Page = request.Page > 0 ? --request.Page : request.Page;
            int skip = request.Page * request.PostsPerPage;

            var data = await _context.Posts.OrderByDescending(p => p.Id).Skip(skip).Take(request.PostsPerPage).ProjectTo<PostListDto>(_mapper.ConfigurationProvider).ToListAsync();
            int total = await _context.Posts.CountAsync();

            return new Envelope<IEnumerable<PostListDto>>(request.Page, total, request.PostsPerPage, data);
        }
    }
}
