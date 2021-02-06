using AutoMapper;
using FreeTime.Application.Common.DTOs;
using FreeTime.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FreeTime.Application.Features.Comments.Queries
{
    public class GetCommentQuery : IRequest<CommentDto>
    {

        public int Id { get; private set; }
        public GetCommentQuery(int id)
        {
            Id = id;
        }

        public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDto>
        {
            private readonly IDataContext _dataContext;
            private readonly IMapper _mapper;
            private readonly IApplicationConfiguration _applicationConfiguration;

            public GetCommentQueryHandler(IDataContext dataContext, IMapper mapper, IApplicationConfiguration applicationConfiguration)
            {
                _dataContext = dataContext;
                _mapper = mapper;
                _applicationConfiguration = applicationConfiguration;
            }
            public async Task<CommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
            {
                var comment = await _dataContext.Comments.FirstOrDefaultAsync(p => p.Id == request.Id);
                return _mapper.Map<CommentDto>(comment);
            }
        }
    }
}
