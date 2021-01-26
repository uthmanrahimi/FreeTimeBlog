﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Comments.Queries
{
    public class GetPostCommentsQuery : IRequest<IEnumerable<CommentDto>>
    {

        public int PostId { get; private set; }
        public int Page { get; private set; }
        public GetPostCommentsQuery(int postId, int page)
        {
            Page = page;
            PostId = postId;
        }

        public class GetPostCommentsQueryHandler : IRequestHandler<GetPostCommentsQuery, IEnumerable<CommentDto>>
        {
            private readonly IDataContext _dataContext;
            private readonly IMapper _mapper;
            private readonly IApplicationConfiguration _applicationConfiguration;

            public GetPostCommentsQueryHandler(IDataContext dataContext, IMapper mapper, IApplicationConfiguration applicationConfiguration)
            {
                _dataContext = dataContext;
                _mapper = mapper;
                _applicationConfiguration = applicationConfiguration;
            }
            public async Task<IEnumerable<CommentDto>> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
            {
                var countToSkip = request.Page * 10;
                return _dataContext.Comments.Where(p => p.PostId == request.PostId && p.IsApproved).OrderBy(p => p.Id)
                      .Skip(countToSkip).Take(10).ProjectTo<CommentDto>(_mapper.ConfigurationProvider);
            }
        }
    }
}
