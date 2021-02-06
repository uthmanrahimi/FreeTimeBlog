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

namespace FreeTime.Application.Features.Comments.Queries
{
    public class GetCommentsQuery : IRequest<Envelope<IEnumerable<CommentDto>>>
    {

        public int Page { get; private set; }
        public GetCommentsQuery(int page)
        {
            Page = page;
        }

        public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, Envelope<IEnumerable<CommentDto>>>
        {
            private readonly IDataContext _dataContext;
            private readonly IMapper _mapper;
            private readonly IApplicationConfiguration _applicationConfiguration;

            public GetCommentsQueryHandler(IDataContext dataContext, IMapper mapper, IApplicationConfiguration applicationConfiguration)
            {
                _dataContext = dataContext;
                _mapper = mapper;
                _applicationConfiguration = applicationConfiguration;
            }
            public async Task<Envelope<IEnumerable<CommentDto>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
            {
                request.Page = request.Page > 0 ? --request.Page : request.Page;
                var countToSkip = request.Page * _applicationConfiguration.PostsPerPage;
                var comments = _dataContext.Comments.OrderBy(p => p.Id)
                      .Skip(countToSkip).Take(_applicationConfiguration.PostsPerPage).ProjectTo<CommentDto>(_mapper.ConfigurationProvider);
                var total = await _dataContext.Comments.CountAsync();
                return new Envelope<IEnumerable<CommentDto>>(request.Page, total, _applicationConfiguration.PostsPerPage, comments);
            }
        }
    }
}
